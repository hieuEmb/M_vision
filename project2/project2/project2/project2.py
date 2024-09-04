import cv2
import numpy as np

duong_dan_anh = r'D:\hk2nam3\thigiacmay\Project\project2\lena_color.png'
img = cv2.imread(duong_dan_anh)

# Lấy kích thước của ảnh
height = len(img)
width = len(img[0])

# Khai báo 3 biến để chứa hình 3 kênh G-R-B
red = np.zeros((width, height, 3), np.uint8)
green = np.zeros((width, height, 3), np.uint8)
blue = np.zeros((width, height, 3), np.uint8)


# Mỗi hình là một ma trận hai chiều nên sẽ dùng 2 vòng for để đọc hết tất cả các điểm ảnh(pixel) có trong hình
for x in range(width):
    for y in range(height):
        R = img[y, x, 2]
        G = img[y, x, 1]
        B = img[y, x, 0]

        # Thiết lập màu cho các kênh
        red[y, x, 2] = R
        green[y, x, 1] = G
        blue[y, x, 0] = B

# Hiển thị ảnh trong cửa sổ
cv2.imshow('Hinh mau RGB goc co gai Lena', img)
# Hiển thị ảnh dùng thư viện OpenCV
cv2.imshow('Kenh RED', red)
cv2.imshow('Kenh GREEN', green)
cv2.imshow('Kenh BLUE', blue)

# Chờ người dùng nhấn một phím bất kỳ để đóng cửa sổ
cv2.waitKey(0)

# Đóng cửa sổ hiển thị
cv2.destroyAllWindows()
