function $(id) {
    return document.getElementById(id);
}

window.onload = function () {
    var target = 0;
    var lender = 0;
    var nums = $("list_num").children;
    var imgs = $("list_img").children;
    var ul = $("list_img");
    var ol = $("list_num");
    //当前索引
    var img_current_index = 0;
    var num_current_index = 0;
    var timer = null;

    for (var i = 0; i < nums.length; i++) {
        nums[i].index = i;
        imgs[i].index = i;
        nums[i].onmouseover = function () {
            if (this.index == img_current_index) {
                this.className = "";
            } else {
                this.className = "current";
            }
            img_current_index = num_current_index = this.index;
            console.log(img_current_index);
            console.log(num_current_index);
            target = -this.index * 555;
        }

        nums[i].onmouseout = function () {
            num_current_index = 0;
            console.log(img_current_index);
            console.log(num_current_index);
        }
    }

    setInterval(function () {
        lender = lender + (target - lender) / 10;
        ul.style.left = lender + "px";
    }, 20)
}