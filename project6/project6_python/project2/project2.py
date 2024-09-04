from tkinter import Y
import cv2
import numpy as np

duong_dan_anh = r'D:\hk2nam3\thigiacmay\Project\project2\lena_color.png'
img = cv2.imread(duong_dan_anh)

# Lấy kích thước của ảnh
height, width, _ = img.shape

# Khai báo 3 biến để chứa hình 3 kênh G-R-B
cyan_img = np.zeros((height, width, 3), np.uint8)
magenta_img = np.zeros((height, width, 3), np.uint8)
yellow_img = np.zeros((height, width, 3), np.uint8)
k_img = np.zeros((height, width, 3), np.uint8)

# Thiết lập màu cho các kênh (nên đặt ngoài vòng lặp)
cyan_img[:, :, 1] = img[:, :, 1]  # Green channel
cyan_img[:, :, 0] = img[:, :, 0]  # Blue channel
       
magenta_img[:, :, 2] = img[:, :, 2]  # Red channel
magenta_img[:, :, 0] = img[:, :, 0]  # Blue channel

yellow_img[:, :, 2] = img[:, :, 2]  # Red channel
yellow_img[:, :, 1] = img[:, :, 1]  # Green channel

k_img = np.minimum.reduce([img[:, :, 2], img[:, :, 1], img[:, :, 0]])  # Copy RGB channels to K image

# Hiển thị ảnh trong cửa sổ
cv2.imshow('Hinh mau RGB goc co gai Lena', img)
# Hiển thị ảnh dùng thư viện OpenCV
cv2.imshow('Kenh CYAN', cyan_img)
cv2.imshow('Kenh MAGENTA', magenta_img)
cv2.imshow('Kenh YELLOW', yellow_img)
cv2.imshow('Kenh K', k_img)

# Chờ người dùng nhấn một phím bất kỳ để đóng cửa sổ
cv2.waitKey(0)

# Đóng cửa sổ hiển thị
cv2.destroyAllWindows()
