import cv2 #sử dụng thư viện sử lý ảnh OpenCV
from PIL import Image #Sử dụng thư viện xử lý ảnh PILLOW hỗ trợ nhiều định dạng ảnh
import numpy as np # Thư viện toán học np


# Khai báo đường dẫn file hình
filehinh= r'D:\hk2nam3\thigiacmay\Project\project3\lena_color.png'

# Đọc ảnh màu dùng thư viện OpenCV
img =cv2.imread(filehinh, cv2.IMREAD_COLOR)

# Đọc ảnh màu dùng thư viện PIL. Ảnh PIL này chúng ta sẽ dùng
imgPIL = Image.open(filehinh)

# Tạo một ảnh có cùng kích thước và mode với ảnh imgPIL
# Ảnh này dùng để chứa kết quả chuyển đổi RGB sang Grayscale
average= Image.new(imgPIL.mode, imgPIL.size)

# Lấy kích thước của ảnh từ imPIL
width= average.size[0]
height= average.size[1]

# Dùng 2 vòng for để quét toàn bộ pixel
for x in range(width):
    for y in range(height):
        # Lấy giá trị điểm ảnh tại vị trí (x,y)
        R, G, B= imgPIL.getpixel((x,y))
        
        # Công thức chuyển đổi điểm ảnh màu RGB thành 
        # điểm ảnh mức xám dùng phương phương Lightness
        MIN = min(R, G, B)
        MAX = max(R, G, B)
        gray= np.uint8((MIN+MAX)/2)   
        # Gán giá trị mức xám vừa tính cho ảnh xám
        average.putpixel((x,y), (gray, gray, gray))
      
      # Chuyển ảnh từ PIL sang OpenCV để hiển thị
anhmucxam= np.array(average)

# Hiển thị ảnh dùng thư viện OpenCV
cv2.imshow('anh mau RGB goc co gai Lena', img)
cv2.imshow('Anh muc xam dung Lightness', anhmucxam)

# Bấm phím bất kỳ để đóng cửa sổ hiển thị ảnh
cv2.waitKey(0)

# Giải phóng bộ nhớ đã cấp phát cho các cửa sổ
cv2.destroyAllWindows()
