function animate(obj, target) {
    clearInterval(obj.timer); // 先清除定时器
    var speed = obj.offsetLeft < target ? 15 : -15; // 用来判断 应该 +  还是 -
    obj.timer = setInterval(function () {
        var result = target - obj.offsetLeft; // 因为他们的差值不会超过15
        obj.style.left = obj.offsetLeft + speed + "px";
        if (Math.abs(result) <= 15) // 如果差值不小于 15 说明到位置了
        {
            clearInterval(obj.timer);
            obj.style.left = target + "px"; // 有5像素差距   我们直接跳转目标位置
        }
    }, 10)
}
window.onload = function () {
    // 获取元素
    var box = document.getElementById("box");
    var ul = document.getElementById("list_img");
    var ulLis = ul.children;
    
    // 因为我们要做无缝滚动  ，所以要克隆第一张，放到最后一张后面去
    // a.appendchild(b)   把 b 放到 a 的最后面
    // 1. 克隆完毕
    ul.appendChild(ul.children[0].cloneNode(true));

    //3. 开始动画部分
    var nums = document.getElementById("list_num").children;
    for (var i = 0; i < nums.length; i++) {
        nums[i].index = i; // 获得当前第几个小li 的索引号
        nums[i].onmouseover = function () {
            for (var j = 0; j < nums.length; j++) {
                nums[j].className = ""; // 所有的都要清空
            }
            this.className = "current";
            animate(ul, -this.index * 555)
            // 调用动画函数  第一个参数  谁动画     第二个  走多少
            square = key = this.index; // 当前的索引号为主
        }
    }
    //  4. 添加定时器
    var timer = null; // 轮播图的定时器
    var key = 0; //控制播放张数
    var square = 0; // 控制小方块
    timer = setInterval(autoplay, 1500); 

    function autoplay() {
        key++; 
        if (key > ulLis.length - 1)
        {
            ul.style.left = 0; 
            key = 1; 
        }
        animate(ul, -key * 555); // 再执行
        square++;
        if (square > nums.length - 1) {
            square = 0;
        }
        for (var i = 0; i < nums.length; i++)
        {
            nums[i].className = "";
        }
        nums[square].className = "current"; 
    }

    box.onmouseover = function () {
        clearInterval(timer);
    }
    box.onmouseout = function () {
        timer = setInterval(autoplay, 1500);
    }
}