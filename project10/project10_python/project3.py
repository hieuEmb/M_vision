import cv2
from PIL import Image
import numpy as np

file_hinh = r'D:\hk2nam3\thigiacmay\Project\project3\lena_color.png'

# Read image using OpenCV
img = cv2.imread(file_hinh, cv2.IMREAD_COLOR)

# Open image using PIL
imgPIL = Image.open(file_hinh)

# Create new images for Y, Cb, Cr, and YCrCb channels
HinhY = Image.new(imgPIL.mode, imgPIL.size)
HinhCb = Image.new(imgPIL.mode, imgPIL.size)
HinhCr = Image.new(imgPIL.mode, imgPIL.size)
HinhYCrCb = Image.new(imgPIL.mode, imgPIL.size)

width = imgPIL.size[0]
height = imgPIL.size[1]

for x in range(width):
    for y in range(height):
        R, G, B = imgPIL.getpixel((x, y))
        Y = np.uint8(16 + ((65.738 * R) / 256) + ((129.057 * G) / 256) + ((25.064 * B) / 256))
        Cb = np.uint8(128 - ((37.495 * R) / 256) - ((74.494 * G) / 256) + ((112.439 * B) / 256))
        Cr = np.uint8(128 + ((112.439 * R) / 256) - ((94.154 * G) / 256) - ((18.285 * B) / 256))

        HinhY.putpixel((x, y), (Y, Y, Y))
        HinhCb.putpixel((x, y), (Cb, Cb, Cb))
        HinhCr.putpixel((x, y), (Cr, Cr, Cr))
        HinhYCrCb.putpixel((x, y), (Cr, Cb, Y))

# Convert PIL images to numpy arrays
AnhY = np.array(HinhY)
AnhCb = np.array(HinhCb)
AnhCr = np.array(HinhCr)
AnhYCrCb = np.array(HinhYCrCb)

# Display images using OpenCV
cv2.imshow('Original Lena Image: ', img)
cv2.imshow('Y Channel: ', AnhY)
cv2.imshow('Cb Channel: ', AnhCb)
cv2.imshow('Cr Channel: ', AnhCr)
cv2.imshow('YCrCb Channel: ', AnhYCrCb)

cv2.waitKey(0)
cv2.destroyAllWindows()
