#include <Adafruit_GFX.h>
#include <Adafruit_NeoMatrix.h>
#include <Adafruit_NeoPixel.h>
#ifndef PSTR
 #define PSTR
#endif

#define PIN 6
#define PANEL_WIDTH 32
#define PANEL_HEIGHT 8
#define NUM_OF_HORIZONTAL_MATRICES 2
#define NUM_OF_VERTICAL_MATRICES 2

#define IMAGE_WIDTH 61
#define IMAGE_HEIGHT 16

// MATRIX DECLARATION:
// Parameter 1 = width of NeoPixel matrix
// Parameter 2 = height of matrix
// Parameter 3 = pin number (most are valid)
// Parameter 4 = matrix layout flags, add together as needed:
//   NEO_MATRIX_TOP, NEO_MATRIX_BOTTOM, NEO_MATRIX_LEFT, NEO_MATRIX_RIGHT:
//     Position of the FIRST LED in the matrix; pick two, e.g.
//     NEO_MATRIX_TOP + NEO_MATRIX_LEFT for the top-left corner.
//   NEO_MATRIX_ROWS, NEO_MATRIX_COLUMNS: LEDs are arranged in horizontal
//     rows or in vertical columns, respectively; pick one or the other.
//   NEO_MATRIX_PROGRESSIVE, NEO_MATRIX_ZIGZAG: all rows/columns proceed
//     in the same order, or alternate lines reverse direction; pick one.
//   See example below for these values in action.
// Parameter 5 = pixel type flags, add together as needed:
//   NEO_KHZ800  800 KHz bitstream (most NeoPixel products w/WS2812 LEDs)
//   NEO_KHZ400  400 KHz (classic 'v1' (not v2) FLORA pixels, WS2811 drivers)
//   NEO_GRB     Pixels are wired for GRB bitstream (most NeoPixel products)
//   NEO_GRBW    Pixels are wired for GRBW bitstream (RGB+W NeoPixel products)
//   NEO_RGB     Pixels are wired for RGB bitstream (v1 FLORA pixels, not v2)

Adafruit_NeoMatrix matrix = Adafruit_NeoMatrix(PANEL_WIDTH, PANEL_HEIGHT, 
                                               NUM_OF_HORIZONTAL_MATRICES, NUM_OF_VERTICAL_MATRICES, 
                                               PIN,
                                               NEO_MATRIX_TOP     + NEO_MATRIX_LEFT +
                                               NEO_MATRIX_COLUMNS + NEO_MATRIX_ZIGZAG +
                                               NEO_TILE_TOP       + NEO_TILE_LEFT +
                                               NEO_TILE_ROWS      + NEO_TILE_ZIGZAG,
                                               NEO_GRB            + NEO_KHZ800);

uint16_t RED = matrix.Color(255,0,0);
uint16_t GREEN = matrix.Color(0,255,0);
uint16_t BLUE = matrix.Color(0,0,255);

enum class State
{
  Asking,
  WaitingForImage,
  WaitingForResponse,
  Reading,
  Writing,
  Rotate,
  Test
};

State state;
int bufferIndex = 0;

bool ifImage = false;
bool haveImage = false;

int x = 0;

byte width;
byte height;

#define BYTES_PER_PIXEL 3
#define MAX_BUFFER_SIZE IMAGE_WIDTH * IMAGE_HEIGHT * BYTES_PER_PIXEL
byte imgBuffer[MAX_BUFFER_SIZE];

// uint16_t readTranslateColor()
// {
//   if(Serial.available() >= 1)
//   {
//     byte incomingByte = Serial.read();

//     buffer[bufferIndex] = incomingByte;

//     if(bufferIndex >= 3)
//     {
//       int r = buffer[0];
//       int g = buffer[1];
//       int b = buffer[2];

//       uint16_t color = matrix.Color(r,g,b);

//       bufferIndex++;

//       matrix.drawPixel(x, y, color);
//       x++;
//       if(x >= IMAGE_WIDTH)
//       {
//         x = 0;
//         y++;
//       }
//     }
//   }
// }

byte ReadNextByte()
{
  while(!Serial.available())
  {
    delayMicroseconds(100);
  }
  
  return Serial.read();
}

void drawImg(int x)
{
  // for(int w = 0; w < 8; w++)
  // {
  //   for(int h = 0; h < 8; h++)
  //   {
  //     if(x+w >= IMAGE_WIDTH)
  //     {
  //       int r = (x+w) - IMAGE_WIDTH;

  //       matrix.drawPixel(r,h,RED);
  //     }
  //     else
  //     {
  //       matrix.drawPixel(x+w,h,RED);
  //     }
      
  //   }
  // }
  int byteCount = 0;
  for(int w = 0; w < width; w++)
  {
    for(int y = 0; y < height; y++)
    {
      byte r = imgBuffer[byteCount++];
      byte g = imgBuffer[byteCount++];
      byte b = imgBuffer[byteCount++];

      if(Serial.available())
      {
        state = State::Reading;
        return;
      }

      if(x+w >= IMAGE_WIDTH)
      {
        int p = (x+w) - IMAGE_WIDTH;

        matrix.drawPixel(p,y,matrix.Color(r,g,b));
      }
      else
      {
        matrix.drawPixel(x+w,y,matrix.Color(r,g,b));
      }
    }
  }

  matrix.show();
}

void setup() 
{
  delay(1000);

  Serial.begin(115200);
  matrix.begin();
  matrix.setTextWrap(false);
  matrix.setBrightness(40);
  matrix.clear();
  matrix.show();

  // state = State::Start;
  state = State::Asking;

 
}

void loop() 
{
  switch(state)
  {
    // case State::Start:
    // {
    //   if(Serial.available())
    //   {
    //     byte flag = Serial.read();

    //     if(flag == 42)
    //     {
    //       Serial.write(42);

    //       state = State::Waiting;
    //     }
    //   }
    // }break;

    case State::Asking:
    {
      Serial.write(42);

      state = State::WaitingForResponse;
      break;
    }
    case State::WaitingForResponse:
    {
      if(Serial.available())
      {
        int response = Serial.read();
        if(response == 1)
        {
          Serial.write(8);
          state = State::WaitingForImage;
          // matrix.drawPixel(1,1,GREEN);
        }
        else if(response == 0)
        {
          if(haveImage == false)
          {
            // matrix.drawPixel(1,1,BLUE);
            state = State::Asking;
          }
          else
          {
            state = State::Rotate;
          }
        }
        // matrix.show();
      }
      break;
    }
    case State::WaitingForImage:
    {
      if(Serial.available())
      {
        state = State::Reading;
      }
      break;
    }
    case State::Reading:
    {
      width = ReadNextByte();
      height = ReadNextByte();
      
      int totalBytes = width * height * BYTES_PER_PIXEL;

      if(totalBytes > MAX_BUFFER_SIZE)
      {
        totalBytes = MAX_BUFFER_SIZE;
      }

      for(int i = 0; i < totalBytes; i++)
      {
        imgBuffer[i] = ReadNextByte();
      }

      haveImage = true;
      state = State::Rotate;

      break;
    }

    case State::Writing:
    {
      int byteCount = 0;
      for(int x = 0; x < width; x++)
      {
        for(int y = 0; y < height; y++)
        {
          byte r = imgBuffer[byteCount++];
          byte g = imgBuffer[byteCount++];
          byte b = imgBuffer[byteCount++];

          matrix.drawPixel(x,y,matrix.Color(r,g,b));
          matrix.show();
        }
      }

      state = State::WaitingForImage;
      break;
    }
    
    case State::Rotate:
    {
      if(x <= 61)
      {
        drawImg(x);
        matrix.clear();
        x++; 
      }
      else if(x >= 61)
      {
        x = 0;
      }

      state = State::Asking;
      
      break;
    }

    case State::Test:
    {
      Serial.write(8);

      int response = ReadNextByte(); 
      
      if(response == 1)
      {
        state = State::WaitingForImage;
      }
      else if(response == 0)
      {
        state = State::Rotate;
      }
      // incrementally test to see what works 

      break;
    }
  }
}