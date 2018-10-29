function $(id) {
    return document.getElementById(id);
}

window.onload = function () {
    var list_Nums = $("list_No").getElementsByTagName("li");

    var currend_Index = 0;


    for (var i = 0; i < list_Nums.length; i++) {
        list_Nums[i].onmouseover = function () {
            if (i != currend_Index) {
                list_Nums[currend_Index].style.backgroundColor = "";
                list_Nums[currend_Index].style.color = "";
            }

            var list_imgs = document.getElementById("list_img").getElementsByTagName("li");

            for (var i = 0; i < list_imgs.length; i++) {
                //将所有的元素隐藏 去掉current类名
                list_imgs[i].className = list_imgs[i].className.replace(" current", "");
                list_Nums[i].className = list_Nums[i].className.replace(" current", "");
                //将当前索引对应的元素设为显示
                if (list_Nums[i] == this) {
                    this.className += " current";
                    list_imgs[i].className += " current";
                }
            }
        }
    }
}