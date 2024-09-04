import cv2
import numpy as np

def rgb_to_xyz(rgb):
    # Ma trận chuyển đổi từ RGB sang XYZ
    rgb_to_xyz_matrix = np.array([[0.4124564, 0.3575761, 0.1804375],
                                  [0.2126729, 0.7151522, 0.0721750],
                                  [0.0193339, 0.1191920, 0.9503041]])

    # Chuyển đổi RGB sang XYZ
    xyz = np.dot(rgb_to_xyz_matrix, rgb)

    return xyz

def chuyen_hinh_rgb_sang_xyz(hinh_goc):
    # Tạo một list để chứa 3 kênh ảnh tương ứng X-Y-Z
    xyz_channels = []

    # Mỗi kênh trong không gian màu XYZ được hiển thị bởi một hình ảnh
    width, height = hinh_goc.shape[1], hinh_goc.shape[0]
    X_channel = np.zeros((height, width), dtype=np.uint8)
    Y_channel = np.zeros((height, width), dtype=np.uint8)
    Z_channel = np.zeros((height, width), dtype=np.uint8)
    XYZ_channel = np.zeros((height, width, 3), dtype=np.uint8)

    for x in range(width):
        for y in range(height):
            # Lấy giá trị điểm ảnh tại vị trí (x, y)
            B, G, R = hinh_goc[y, x]

            # Chuyển đổi RGB sang XYZ
            xyz_values = rgb_to_xyz(np.array([R, G, B]))

            # Gán giá trị XYZ cho từng pixel trong ma trận
            X_channel[y, x] = int(xyz_values[0])
            Y_channel[y, x] = int(xyz_values[1])
            Z_channel[y, x] = int(xyz_values[2])
            XYZ_channel[y, x] = (int(xyz_values[2]), int(xyz_values[1]), int(xyz_values[0]))

    # Add các kình tương ứng vào các kênh màu X-Y-Z vào list
    xyz_channels.extend([X_channel, Y_channel, Z_channel, XYZ_channel])

    # Hàm trả về một list 4 ảnh Bitmap tương ứng với 3 kênh màu X-Y-Z và ảnh kết hợp XYZ
    return xyz_channels

# Đường dẫn đến file hình
file_hinh = r'C:\Users\Admin\Desktop\Thi_Giac\Bai_9\lena_color.png'

# Đọc ảnh màu dùng thư viện OpenCV
hinh_goc = cv2.imread(file_hinh)

# Gọi hàm chuyển đổi RGB sang XYZ
xyz_channels = chuyen_hinh_rgb_sang_xyz(hinh_goc)

# Hiển thị ảnh gốc và từng kênh màu X, Y, Z, và ảnh kết hợp XYZ
cv2.imshow('Original Image', hinh_goc)
cv2.imshow('X Channel', xyz_channels[0])
cv2.imshow('Y Channel', xyz_channels[1])
cv2.imshow('Z Channel', xyz_channels[2])
cv2.imshow('XYZ Channel', xyz_channels[3])

# Bấm phím bất kỳ để đóng cửa sổ hiển thị ảnh
cv2.waitKey(0)

# Giải phóng bộ nhớ đã cấp phát cho các cửa sổ
cv2.destroyAllWindows()
