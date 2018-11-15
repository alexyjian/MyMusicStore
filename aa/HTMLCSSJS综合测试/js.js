function $(id) {
    return document.getElementById(id);
}

window.onload = function () {
    var target = 0;
    var lender = 0;
    var nums = $("list_num").children;
    var imgs = $("list_img").getElementsByTagName("li");
    var ul = $("list_img");
    //当前索引
    var current_index = 0;
    var timer = null;

    timer = setInterval(autoPlay, 1500);

    for (var i = 0; i < nums.length; i++) {
        nums[i].index = i;
        imgs[i].index = i;
        nums[i].onmouseover = function () {
            for (var j = 0; j < nums.length; j++) {
                nums[j].className = "";
            }
            current_index = this.index;
            this.className = "current";
            target = -this.index * 555;
        }
    }

    ul.onmouseover = function () {
        clearInterval(timer);
    }

    ul.onmouseout = function () {
        timer = setInterval(autoPlay, 1500);
    }

    setInterval(function () {
        lender = lender + (target - lender) / 10;
        ul.style.left = lender + "px";
    }, 20);

    function autoPlay() {
        if(current_index == 4) {
            current_index = -1;
        }
        current_index++;
        for (var i = 0; i < nums.length; i++) {
            nums[i].className = "";
        }
        nums[current_index].className = "current";
        target = -current_index * 555;

    }
}
