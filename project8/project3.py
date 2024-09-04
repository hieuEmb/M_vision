

import cv2 #sử dụng thư viện sử lý ảnh OpenCV
from PIL import Image #Sử dụng thư viện xử lý ảnh PILLOW hỗ trợ nhiều định dạng ảnh
import numpy as np # Thư viện toán học np
import math


# Khai báo đường dẫn file hình
filehinh= r'C:\Users\Admin\Desktop\Thi_Giac\Bai_8\lena_color.png'

# Đọc ảnh màu dùng thư viện OpenCV
img =cv2.imread(filehinh, cv2.IMREAD_COLOR)

# Đọc ảnh màu dùng thư viện PIL. Ảnh PIL này chúng ta sẽ dùng
imgPIL = Image.open(filehinh)

# Tạo một ảnh có cùng kích thước và mode với ảnh imgPIL
# Ảnh này dùng để chứa kết quả chuyển đổi RGB sang Grayscale
h= Image.new(imgPIL.mode, imgPIL.size)
s= Image.new(imgPIL.mode, imgPIL.size)
v= Image.new(imgPIL.mode, imgPIL.size)
hsv= Image.new(imgPIL.mode, imgPIL.size)

# Lấy kích thước của ảnh từ imPIL
width= h.size[0]
height=h.size[1]

# Dùng 2 vòng for để quét toàn bộ pixel
for x in range(width):
    for y in range(height):
        # Lấy giá trị điểm ảnh tại vị trí (x,y)
        R, G, B= imgPIL.getpixel((x,y))
        
       
        # t1 là phần tử số của công thức
        t1 = ((R - G) + (R - B)) / 2

        # t2 là phần mẫu số của công thức tính góc theta
        t2 = np.sqrt((R - G) * (R - G) + (R - B) * (G - B))
        
        theta = (np.arccos(t1/t2))
        theta = np.uint8((theta))
              
        if B <= G:
            H =np.uint8(theta)
        else:
            H = np.uint8(2*math.pi-theta)
        H = np.uint8(np.degrees(H))
        
       
        S = np.uint8(1 - ((3 * min(R, G, B)) / (R + G + B))*255)
        V= np.uint8(np.max([R,G,B]))

        # Gán giá trị mức xám vừa tính cho ảnh xám
        h.putpixel((x,y), (H, H, H))
        s.putpixel((x,y), (S, S, S))
        v.putpixel((x,y), (V, V, V))
        hsv.putpixel((x,y), (V,S,H))
      # Chuyển ảnh từ PIL sang OpenCV để hiển thị
Hue= np.array(h)
Saturation= np.array(s)
Intensity= np.array(v)
HSI= np.array(hsv)
# Hiển thị ảnh dùng thư viện OpenCV
cv2.imshow('anh mau RGB goc co gai Lena', img)
cv2.imshow('Hue', Hue)
cv2.imshow('Saturation', Saturation)
cv2.imshow('Intensity', Intensity)
cv2.imshow('HSV', HSI)

# Bấm phím bất kỳ để đóng cửa sổ hiển thị ảnh
cv2.waitKey(0)

# Giải phóng bộ nhớ đã cấp phát cho các cửa sổ
cv2.destroyAllWindows()