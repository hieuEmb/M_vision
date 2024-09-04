import cv2
import numpy as np
from PIL import Image

# Đường dẫn đến file ảnh
filehinh = r'D:\hk2nam3\thigiacmay\Project\project3\lena_color.png'

# Đọc ảnh màu dùng thư viện OpenCV
img = cv2.imread(filehinh, cv2.IMREAD_COLOR)

# Đọc ảnh màu dùng thư viện PIL
imgPIL = Image.open(filehinh)

# Tạo ảnh mới để chứa kết quả chuyển đổi thành ảnh nhận dạng biên
edgeImage = Image.new(imgPIL.mode, imgPIL.size)

# Lấy kích thước của ảnh từ imgPIL
width, height = edgeImage.size

# Thiết lập giá trị ngưỡng để tính biên
nguong = 130

# Duyệt qua từng pixel trong ảnh
for x in range(1, width - 1):
    for y in range(1, height - 1):
        # Lấy giá trị màu RGB tại vị trí (x, y)
        R, G, B = imgPIL.getpixel((x, y))
        
        # Chuyển đổi sang ảnh mức xám dùng phương pháp Luminance
        gray = np.uint8(0.2126 * R + 0.7152 * G + 0.0722 * B)

        # Tính gradient gx và gy theo phương pháp Sobel
        gx = (imgPIL.getpixel((x + 1, y - 1))[0] + 2 * imgPIL.getpixel((x + 1, y))[0] + imgPIL.getpixel((x + 1, y + 1))[0]
              - imgPIL.getpixel((x - 1, y - 1))[0] - 2 * imgPIL.getpixel((x - 1, y))[0] - imgPIL.getpixel((x - 1, y + 1))[0])
        
        gy = (imgPIL.getpixel((x - 1, y + 1))[0] + 2 * imgPIL.getpixel((x, y + 1))[0] + imgPIL.getpixel((x + 1, y + 1))[0]
              - imgPIL.getpixel((x - 1, y - 1))[0] - 2 * imgPIL.getpixel((x, y - 1))[0] - imgPIL.getpixel((x + 1, y - 1))[0])

        # Tính độ lớn của gradient tại điểm ảnh
        gradient = np.sqrt(gx ** 2 + gy ** 2)

        # Phân loại điểm ảnh thành cạnh hoặc nền dựa vào ngưỡng
        if gradient <= nguong:
            edgeImage.putpixel((x, y), (0, 0, 0))  # Đen cho nền
        else:
            edgeImage.putpixel((x, y), (255, 255, 255))  # Trắng cho cạnh

# Chuyển ảnh từ PIL sang OpenCV để hiển thị
anh_edgeImage = np.array(edgeImage)

# Hiển thị ảnh dùng thư viện OpenCV
cv2.imshow('Anh goc', img)
cv2.imshow('Anh nhan dang bien', anh_edgeImage)

# Chờ phím bấm bất kỳ để đóng cửa sổ
cv2.waitKey(0)

# Đóng cửa sổ khi có phím bấm
cv2.destroyAllWindows()
