import cv2      # Sử dụng thư viện xử lý ảnh OpenCV
import numpy as np # Thuật toán xử lý ma trận

# Khai báo đường dẫn file hình
filehinh = r"D:\hk2nam3\thigiacmay\tailieu\lena_color.png"

# Đọc ảnh màu
img = cv2.imread(filehinh)

# Chuyển ảnh màu RGB sang ảnh mức xám dùng phương pháp Luminance
anhxam = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

# Chọn ngưỡng so sánh
Nguong = 130

# Nhận dạng đường biên sử dụng ma trận Robert
Sx = np.array([[-1, 0], [0, 1]])
Sy = np.array([[0, -1], [1, 0]])
imageSobel = np.zeros_like(anhxam)
for x in range(1, anhxam.shape[0] - 1):
    for y in range(1, anhxam.shape[1] - 1):
        gx = gy = 0
        for i in range(x - 1, x + 1):
            for j in range(y - 1, y + 1):
                g = anhxam[i, j]              
                gx += g * Sx[i - (x - 1), j - (y - 1)]
                gy += g * Sy[i - (x - 1), j - (y - 1)]
        M = np.abs(gx) + np.abs(gy)
        if M < Nguong:
            imageSobel[x, y] = 0
        else:
            imageSobel[x, y] = 255

# Hiển thị ảnh
cv2.imshow('Anh mau RGB goc', img)
cv2.imshow('Anh da duoc nhan dang duong bien:', imageSobel)

# Bấm phím bất kỳ để đóng cửa sổ hiển thị ảnh
cv2.waitKey(0)

# Giải phóng bộ nhớ đã cấp phát cho cửa sổ
cv2.destroyAllWindows()
