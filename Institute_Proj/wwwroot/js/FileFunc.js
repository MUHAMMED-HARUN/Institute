//// تعرض الصورة في عنصر معين حسب الكلاس
//function previewImage(inputElement, targetClass) {
//    const file = inputElement.files[0];

//    if (file && file.type.startsWith("image/")) {
//        const reader = new FileReader();

//        reader.onload = function (e) {
//            const previewContainer = document.querySelector(`.${targetClass}`);
//            if (previewContainer) {
//                previewContainer.innerHTML = `<img src="${e.target.result}" alt="الصورة" style="max-width: 100%; max-height: 200px;" />`;
//            }
//        };

//        reader.readAsDataURL(file);
//    }
//}


//function previewImage(inputElement, targetClass) {
//    const file = inputElement.files[0];

//    if (file && file.type.startsWith("image/")) {
//        const reader = new FileReader();

//        reader.onload = function (e) {
//            const previewContainer = document.querySelector(`.${targetClass}`);
//            if (previewContainer) {
//                previewContainer.innerHTML = `<img src="${e.target.result}" alt="الصورة" style="max-width: 100%; max-height: 200px;" />`;
//            }
//        };

//        reader.readAsDataURL(file);
//    }
//}

//function previewImage(inputElement, targetClass) {
//    const file = inputElement.files[0];

//    if (!file) return;

//    if (file.size > 5 * 1024 * 1024) { // أكثر من 5 ميغا
//        alert("الرجاء اختيار صورة بحجم أقل من 5 ميغابايت.");
//        inputElement.value = ""; // إعادة التهيئة
//        return;
//    }

//    if (file.type.startsWith("image/")) {
//        const reader = new FileReader();

//        reader.onload = function (e) {
//            const previewContainer = document.querySelector(`.${targetClass}`);
//            if (previewContainer) {
//                previewContainer.innerHTML = `<img src="${e.target.result}" alt="الصورة" style="max-width: 100%; max-height: 200px;" />`;
//            }
//        };

//        reader.readAsDataURL(file);
//    } else {
//        alert("الملف المختار ليس صورة.");
//    }
//}
function previewImage(inputElement, targetClass) {
    try {
        const file = inputElement.files[0];
        if (!file) return;

        console.log("Selected file:", file.name);

        if (!file.type.startsWith("image/")) {
            alert("الملف ليس صورة.");
            return;
        }

        const reader = new FileReader();

        reader.onload = function (e) {
            const previewContainer = document.querySelector(`.${targetClass}`);
            if (previewContainer) {
                const img = previewContainer.getElementsByTagName("img")[0];
                const hiddenInput = previewContainer.getElementsByTagName("input")[0];
                
                if (img) img.src = e.target.result;
                if (hiddenInput) hiddenInput.value = file.name;
            }
        };

        reader.onerror = function (err) {
            console.error("حدث خطأ في FileReader:", err);
            alert("خطأ في قراءة الصورة.");
        };

        reader.readAsDataURL(file);
    } catch (ex) {
        console.error("استثناء أثناء عرض الصورة:", ex);
        alert("حدث استثناء داخلي.");
    }
}
function DeleteImageSrc(targetImg) {
    image = document.getElementById(targetImg)
    if (image) {
        image.src = "";
    }
}
function DeleteInputValue(TargetInput) {
    input = document.getElementById(TargetInput)
    if (input) {
        input.value = "";
    }
}


