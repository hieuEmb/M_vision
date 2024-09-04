import cv2
from PIL import Image
import numpy as np

def color_image_smoothing(image, mask_size):
    # Chuyển ảnh từ OpenCV sang NumPy array, sau đó sang PIL
    img_pil = Image.fromarray(cv2.cvtColor(image, cv2.COLOR_BGR2RGB))
    width, height = img_pil.size
    
    n = mask_size // 2
    # Tạo Image mới để chứa ảnh sau khi làm mượt
    smoothed_image = Image.new("RGB", (width, height))

    for x in range(n, width - n):
        for y in range(n, height - n):
            Rs, Gs, Bs = 0, 0, 0
            
            # Quét các điểm có trong mặt nạ kích thước mask_size x mask_size
            for i in range(x - n, x + n + 1):
                for j in range(y - n, y + n + 1):
                    R, G, B = img_pil.getpixel((i, j))
                    Rs += R
                    Gs += G
                    Bs += B
            
            # Tính trung bình cộng giá trị RGB trong mặt nạ
            k = mask_size * mask_size
            Rs //= k
            Gs //= k
            Bs //= k

            # Đặt giá trị pixel đã làm mượt vào Image mới
            smoothed_image.putpixel((x, y), (Bs, Gs, Rs))
    return smoothed_image

if __name__ == "__main__":
    # Đường dẫn của ảnh gốc
    image_path = r"D:\hk2nam3\thigiacmay\tailieu\lena_color.png"

    # Đọc ảnh gốc sử dụng OpenCV
    original_image = cv2.imread(image_path)

    # Hiển thị ảnh gốc sử dụng OpenCV
    cv2.imshow("Original Image", original_image)

    # Gọi hàm chuyển đổi RGB sang CMYK
    smoothed_image_3x3 = color_image_smoothing(original_image, 3)
    cv2.imshow("Smoothed Image 3x3", np.array(smoothed_image_3x3))

    smoothed_image_5x5 = color_image_smoothing(original_image, 5)
    cv2.imshow("Smoothed Image 5x5", np.array(smoothed_image_5x5))

    smoothed_image_7x7 = color_image_smoothing(original_image, 7)
    cv2.imshow("Smoothed Image 7x7", np.array(smoothed_image_7x7))

    smoothed_image_9x9 = color_image_smoothing(original_image, 9)
    cv2.imshow("Smoothed Image 9x9", np.array(smoothed_image_9x9))

    # Chờ người dùng nhấn một phím bất kỳ để đóng cửa sổ
    cv2.waitKey(0)

    # Đóng cửa sổ hiển thị
    cv2.destroyAllWindows()
