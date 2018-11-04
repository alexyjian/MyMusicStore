function animate(obj, target) {
    clearInterval(obj.timer);  // 先清除定时器
    var speed = obj.offsetLeft < target ? 15 : -15;  // 用来判断 应该 +  还是 -
    obj.timer = setInterval(function () {
        var result = target - obj.offsetLeft; // 因为他们的差值不会超过15
        obj.style.left = obj.offsetLeft + speed + "px";
        if (Math.abs(result) <= 15)  // 如果差值不小于 15 说明到位置了
        {
            clearInterval(obj.timer);
            obj.style.left = target + "px";  // 有5像素差距   我们直接跳转目标位置
        }
    }, 10)
}
window.onload = function () {
    // 获取元素
    var box = document.getElementById("all");  // 大盒子
    var ul = document.getElementById("ul");
    var ulLis = ul.children;

    // 操作元素

    // 因为我们要做无缝滚动  ，所以要克隆第一张，放到最后一张后面去
    // a.appendchild(b)   把 b 放到 a 的最后面
    // 1. 克隆完毕
    ul.appendChild(ul.children[0].cloneNode(true));

    // 2. 创建 ol  和  小 li
    console.log(ulLis.length);
    var ol = document.createElement("ol");  // 生成的是ol
    box.appendChild(ol); // 把ol 追加到  box 里面
    for (var i = 0; i < ulLis.length - 1; i++) {
        var li = document.createElement("li");
        li.innerHTML = i + 1;  //  给里面小的li 文字  1 2 3 4 5
        ol.appendChild(li);  // 添加到 ol 里面
    }
    ol.children[0].className = "current";

    //3. 开始动画部分
    var olLis = ol.children;
    for (var i = 0; i < olLis.length; i++) {
        olLis[i].index = i;  // 获得当前第几个小li 的索引号
        olLis[i].onmouseover = function () {
            for (var j = 0; j < olLis.length; j++) {
                olLis[j].className = "";  // 所有的都要清空
            }
            this.className = "current";
            animate(ul, -this.index * 500)
            // 调用动画函数  第一个参数  谁动画     第二个  走多少
            square = key = this.index;  // 当前的索引号为主
        }
    }
    //  4. 添加定时器
    var timer = null;   // 轮播图的定时器
    var key = 0;  //控制播放张数
    var square = 0; // 控制小方块
    timer = setInterval(autoplay, 4000);  // 开始轮播图定时器
    function autoplay() {
        key++;  // 先 ++
        if (key > ulLis.length - 1)  // 后判断
        {
            ul.style.left = 0;  // 迅速调回
            key = 1;  // 因为第6张就是第一张  第6张播放 下次播放第2张
        }
        animate(ul, -key * 500);  // 再执行
        // 小方块
        square++;
        if (square > olLis.length - 1) {
            square = 0;
        }
        for (var i = 0; i < olLis.length; i++)   // 先清除所有的
        {
            olLis[i].className = "";
        }
        olLis[square].className = "current";  // 留下当前的
    }
    //last最后  鼠标经过大盒子要停止定时器
    box.onmouseover = function () {
        clearInterval(timer);
    }
    box.onmouseout = function () {
        timer = setInterval(autoplay, 4000);  // 开始轮播图定时器
    }
}