import cv2      # Sử dụng thư viện xử lý ảnh Opencv
from PIL import Image  # Thư viện xử lý ảnh PILLOW hỗ trợ nhiều định dạng ảnh
import numpy as np # Thuật toán xử lý ma trận

# Khai báo đường dẫn file hình
filehinh = r'C:\Users\Admin\Desktop\Thi_Giac\Bai_15\lena_color.png'

# Đọc ảnh màu dùng thư viện Opencv
img = cv2.imread(filehinh, cv2.IMREAD_COLOR)

# Đọc ảnh màu dùng thư viện PILLOW (Ảnh PIL dùng để thực hiện các tác vụ xử lý  và tính toán thay vì dùng Opencv)
imgPIL = Image.open(filehinh)

w=imgPIL.size[0]
h=imgPIL.size[1]

Nguong=130
#nhan dang bien sobel
Sx=np.array([[-1,-2,-1],[0,0,0],[1,2,1]])
Sy=np.array([[-1,0,1],[-2,0,2],[-1,0,1]])
hinhsobel=Image.new(imgPIL.mode,imgPIL.size)
for x in range(1, w -1):
    for y in range(1, h -1):
        gxx=gyy=gxy=gxR=gxG=gxB=gyR=gyG=gyB=0
        for i in range (x -1,x+2):
            for j in range (y -1, y+2):
                gR,gG,gB=imgPIL.getpixel((i,j))
                gxR +=gR * Sx[j - y + 1, i - x + 1]
                gyR +=gR * Sy[j - y + 1, i - x + 1]
                gxG +=gG * Sx[j - y + 1, i - x + 1]
                gyG +=gG * Sy[j - y + 1, i - x + 1]
                gxB +=gB * Sx[j - y + 1, i - x + 1]
                gyB +=gB * Sy[j - y + 1, i - x + 1]
        gxx=np.abs(gxR)**2 + np.abs(gxG)**2 + np.abs(gxB)**2
        gyy=np.abs(gyR)**2 + np.abs(gyG)**2 + np.abs(gyB)**2
        gxy=(gxR)*(gyR)+(gxG)*(gyG)+(gxB)*(gyB)
        t3= 0.5*np.arctan2((2*gxy),(gxx-gyy))
        f0= np.sqrt(0.5*((gxx+gyy)+(gxx+gyy)*(np.cos(2*t3))+2*gxy*np.sin(2*t3)))
        if f0 < Nguong:
            hinhsobel.putpixel((x,y),(0,0,0))
        else:
            hinhsobel.putpixel((x,y),(255,255,255))
hinhduongbien= np.array(hinhsobel)

# Hiển thị ảnh dùng thư viện opencv
cv2.imshow('Anh duong bien:',hinhduongbien)

# Bấm phím bất kỳ để đóng cửa sổ hiển thị ảnh
cv2.waitKey(0)

# Giải phóng bộ nhớ đã cấp phát cho cửa sổ
cv2.destroyAllWindows()