import sys
import codecs
import tkinter as tk
from tkinter import filedialog, messagebox
from tkinter import ttk
from keras.models import load_model
import numpy as np
from matplotlib import pyplot as plt
from PIL import Image, ImageTk
from PIL import Image, ImageDraw, ImageFont

# Thay đổi mã hóa mặc định của đầu ra console sang UTF-8
sys.stdout = codecs.getwriter("utf-8")(sys.stdout.detach())

def safe_print(*args, **kwargs):
    try:
        print(*args, **kwargs)
    except UnicodeEncodeError:
        encoded_args = [str(arg).encode('utf-8', errors='ignore').decode('utf-8') for arg in args]
        print(*encoded_args, **kwargs)

# Tải mô hình đã huấn luyện
try:
    model = load_model(r'D:/old/hk2nam3/thigiacmay/Project/final_project/project/model/brats_3d.hdf5', compile=False)
    safe_print("Model loaded successfully.")
except Exception as e:
    safe_print("Error loading model:", e)
    messagebox.showerror("Error", "Failed to load model.")

# Hàm để dự đoán hình ảnh
def predict_image(file_path):
    try:
        test_img = np.load(file_path)
        test_img_input = np.expand_dims(test_img, axis=0)
        test_prediction = model.predict(test_img_input)
        test_prediction_argmax = np.argmax(test_prediction, axis=4)[0, :, :, :]
        return test_img, test_prediction_argmax
    except Exception as e:
        safe_print("Error during prediction:", e)
        messagebox.showerror("Error", "Prediction failed.")
        return None, None

# Hàm để hiển thị hình ảnh
def show_image():
    file_path = filedialog.askopenfilename(filetypes=[("Numpy Files", "*.npy")])
    if file_path:
        test_img, test_prediction_argmax = predict_image(file_path)
        if test_img is not None and test_prediction_argmax is not None:
            n_slice = 55
            fig, ax = plt.subplots(1, 2, figsize=(12, 8))
            ax[0].set_title('Testing Image')
            ax[0].imshow(test_img[:, :, n_slice, 1], cmap='gray')

            ax[1].set_title('Prediction on test image')
            ax[1].imshow(test_prediction_argmax[:, :, n_slice])
            plt.show()

# Hàm để thay đổi kích thước hình ảnh bằng Pillow
def resize_image(image_path, size):
    image = Image.open(image_path)
    image = image.resize(size, Image.LANCZOS)  # Thay thế ANTIALIAS bằng LANCZOS
    return ImageTk.PhotoImage(image)

def start_program():
    root.destroy()

    # Create a new root window for the new program window
    new_window = tk.Tk()
    new_window.title("New Window")
    new_window.configure(bg="#C0FFFF")
    new_window.geometry("1040x720")  # Set the size of the window
    new_window.resizable(False, False)  # Lock the window size

    global right_photo
    # Load and resize the right image
    right_image = Image.open(r"D:/old/hk2nam3/thigiacmay/tailieu/vd.png")
    right_image = right_image.resize((1038, 461))
    right_photo = ImageTk.PhotoImage(right_image)

    # Display the image on a Canvas
    canvas = tk.Canvas(new_window, width=1038, height=461, bg="#C0FFFF")
    canvas.place(x=0, y=60)
    canvas.create_image(0, 0, anchor=tk.NW, image=right_photo)

    canvas_color = canvas.cget('bg')
    new_window_label = tk.Label(new_window, text="ẢNH VD KHI CHẠY MODEL", font=("Arial", 18), bg=canvas_color)
    new_window_label.pack()
    new_window_label.place(x=380, y=20)

    hinh1 = tk.Label(new_window, text="Image 1", font=("Arial", 18), bd=0)
    hinh1.pack()
    hinh1.place(x=160, y=485)

    hinh2 = tk.Label(new_window, text="Image 2", font=("Arial", 18), bd=0)
    hinh2.pack()
    hinh2.place(x=490, y=485)

    hinh3 = tk.Label(new_window, text="Image 3", font=("Arial", 18), bd=0)
    hinh3.pack()
    hinh3.place(x=820, y=485)

    # Create a new note string
    note_info = "Màu xanh đậm: u tăng tăng cường (ET)\n" \
                "Màu xanh lá cây: u không tăng cường / u nekrotic (NET/NCR) \n" \
                "Màu vàng: sưng tấy xung quanh u (ED)\n"

    note = tk.Label(new_window, text=note_info, font=("Arial", 14), bg=canvas_color, anchor="w", width=100)
    note.place(x=300, y=530)

    hinh4 = tk.Label(new_window, text="Image 1: Ảnh MRI ", font=("Arial", 14), bg=canvas_color)
    hinh4.pack()
    hinh4.place(x=20, y=620)

    hinh5 = tk.Label(new_window, text="Image 2: Nhãn của ảnh MRI", font=("Arial", 14), bg=canvas_color)
    hinh5.pack()
    hinh5.place(x=20, y=645)

    hinh6 = tk.Label(new_window, text="Image 3: Ảnh đã được dự đoán", font=("Arial", 14), bg=canvas_color)
    hinh6.pack()
    hinh6.place(x=20, y=670)

    # Create the "Load and Predict Image" button
    button = ttk.Button(new_window, text="Load and Predict Image", command=show_image, style='Custom.TButton')
    button.place(x=20, y=530)

    # Define button style
    style = ttk.Style()
    style.configure('Custom.TButton', font=('Arial', 12))

    new_window.mainloop()

##########################################################################################
# Tạo cửa sổ giao diện
root = tk.Tk()
root.title("Brain Tumor Segmentation")
root.geometry("1050x670")  # Đặt kích thước cửa sổ
root.resizable(False, False)  # Khóa kích thước cửa sổ


# Thay đổi kích thước ảnh nền để phù hợp với cửa sổ
background_image = Image.open(r"D:/old/hk2nam3/thigiacmay/tailieu/NEN_2.JPG")
background_image = background_image.resize((1050, 670))

# Tạo một canvas
canvas = tk.Canvas(root, width=1050, height=670)
canvas.pack()

# Chuyển đổi ảnh nền thành PhotoImage
background_photo = ImageTk.PhotoImage(background_image)
canvas.create_image(0, 0, anchor=tk.NW, image=background_photo)

# Load và thay đổi kích thước ảnh bên trái
left_image = Image.open(r"D:/old/hk2nam3/thigiacmay/tailieu/LOGO.png")
left_image = left_image.resize((150, 150))
left_photo = ImageTk.PhotoImage(left_image)


# Hiển thị ảnh bên trái
left_image_label = tk.Label(root, image=left_photo, bg='white')
left_image_label.place(x=450, y=160)


# Vẽ chữ trên canvas
text = "TRƯỜNG ĐẠI HỌC SƯ PHẠM KỸ THUẬT TPHCM"
canvas.create_text(1050/2, 50, text=text, font=("Arial", 16, "bold"), fill="black")

# Vẽ các nhãn trên canvas
faculty_text = "KHOA CƠ KHÍ CHẾ TẠO MÁY"
canvas.create_text(1050/2, 80, text=faculty_text, font=("Arial", 16, "bold"), fill="black")

course_text = "BỘ MÔN CƠ ĐIỆN TỬ"
canvas.create_text(1050/2, 110, text=course_text, font=("Arial", 16, "bold"), fill="black")

course_text = "  0o0  "
canvas.create_text(1050/2, 140, text=course_text, font=("Arial", 16, "bold"), fill="black")

report_text = "BÁO CÁO CUỐI KỲ"
canvas.create_text(1050/2, 330, text=report_text, font=("Arial", 16, "bold"), fill="black")

subject_text = "Môn HỌC: THỊ GIÁC MÁY"
canvas.create_text(1050/2, 360, text=subject_text, font=("Arial", 16, "bold"), fill="black")

topic_text = "ĐỀ TÀI: MÔ HÌNH PHÂN ĐOẠN CÁC TIỂU VÙNG BÊN TRÊN KHỐI U NÃO"
canvas.create_text(1050/2, 390, text=topic_text, font=("Arial", 16, "bold"), fill="black")

# Thông tin giảng viên và sinh viên thực hiện
instructor_text = "NHÓM: 232MAVI332529"
canvas.create_text(1050/2, 420, text=instructor_text, font=("Arial", 14, "bold"), fill="black")

instructor_text = "GVHD: TS.NGUYỄN VĂN THÁI"
canvas.create_text(1050/2, 450, text=instructor_text, font=("Arial", 14, "bold"), fill="black")

# Tạo chuỗi văn bản
student_info = "HỌ & TÊN SINH VIÊN\tMSSV\n" \
               "Phạm Trung Hiếu\t\t21146459\n" \
               "Lê Đình Tấn An\t\t21143104\n" \
               "Lê Phúc Trường\t\t21146528"

# Vẽ văn bản trên canvas và căn chỉnh nó sang bên trái
canvas.create_text(600, 530, text=student_info, font=("Arial", 14), fill="black", anchor="w")



# Tạo một nút để tải và dự đoán hình ảnh
button = ttk.Button(root, text="START PROGRAM", command=start_program, style='Custom.TButton')
button.place(relx=1.0, rely=0.0, anchor="ne", x=-70, y=580)

# Tạo một kiểu cho nút nhấn
style = ttk.Style()

# Thiết lập màu nền và màu chữ cho nút nhấn
style.configure('Custom.TButton', foreground='black', background='black', font=('Arial', 11))

# Thiết lập padding và border cho nút nhấn
style.layout('Custom.TButton', [
    ('Button.border', {'children':
        [('Button.focus', {'children':
            [('Button.padding', {'children':
                [('Button.label', {'side': 'top', 'sticky': 'nswe'})],
                'sticky': 'nswe'})],
            'sticky': 'nswe'})],
        'sticky': 'nswe'})
])

root.mainloop()
