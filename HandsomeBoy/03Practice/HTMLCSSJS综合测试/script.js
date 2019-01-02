window.onload = function () {
    var box = document.getElementById("box");
    var ol = document.getElementById("ad_ol").getElementsByTagName("li")
    var ul = document.getElementById("ad_ul");
    var times = null;
    var index = 0;
    var leader = 0;
    var target = 0;

    times = setInterval(automatic, 2000);
    //自动切换图片的索引
    function automatic() {
        index++;
        if (index >= ol.length) {
            index = 0;
        }
        //吧索引加到切换图片函数里
        cutimages(index);
    }
    //用于切换图片的函数
    function cutimages(cuindex) {
        for (var i = 0; i < ol.length; i++) {

            for (var i = 0; i < ol.length; i++) {
                ol[i].className = '';
            }
            ol[cuindex].className = "current";
            target = ol[cuindex].index * -500;
        }
    }
    //切换图片的过渡效果
    setInterval(function () {
        leader = leader + (target - leader) / 10;
     
        ul.style.left = leader + "px";
    }, 30)
    // 当鼠标悬浮在图片上时，暂停切换
    box.onmouseover = function () {
        clearInterval(times);
        
    }
    // 当鼠标离开图片上时，继续切换
    box.onmouseout = function () {
        times = setInterval(automatic, 2000);
    }
    //用于当鼠标滑到对应导航时获取该索引
    for (var i = 0; i < ol.length; i++) {
        ol[i].index = i;
        ol[i].onmouseover = function () {
            clearInterval(times);
            cutimages(this.index);
            index = this.index;
        }
    }

}