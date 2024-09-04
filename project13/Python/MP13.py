import cv2 
from PIL import Image # thư vien xu li anh
import numpy as np

filehinh = r"D:\hk2nam3\thigiacmay\tailieu\lena_color.png"
imgPIL = Image.open(filehinh)
img=cv2.imread("lena_color.jpg", cv2.IMREAD_COLOR)

chanelSHEG=Image.new(imgPIL.mode,imgPIL.size)
width = imgPIL.size[0]
height = imgPIL.size[1]
#khai báo giá trị xy và ngưỡng
X1= 80
X2=150
Y1=400
Y2= 500
Nguong=45
Gs = 0
Rs = 0
Bs = 0
for x in range(X1,X2):
    for y in range(Y1,Y2):
        R,G,B=imgPIL.getpixel((x,y))
        Rs += R
        Gs += G
        Bs += B

S= (X2-X1+1)*(Y2-Y1+1)
Rs= Rs /S
Gs= Gs /S
Bs= Bs /S

for x in range (width):
    for y in range(height):
        R1,G1,B1=imgPIL.getpixel((x,y))
        D = np.sqrt((R1 - Rs)**2 + (G1 - Gs)**2 + (B1 - Bs)**2)
        if D <Nguong:
            chanelSHEG.putpixel((x,y),(255,255,255))
        else:
            chanelSHEG.putpixel((x,y),(B1,G1,R1))

sheg= np.array(chanelSHEG)
cv2.imshow('Hinh phan doan mau', sheg)
cv2.waitKey(0)
cv2.destroyAllWindows()