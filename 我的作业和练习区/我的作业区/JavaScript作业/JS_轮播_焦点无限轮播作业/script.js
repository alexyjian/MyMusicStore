//页面加载完成时
window.onload = function () {
    var ul = document.getElementById('head_ul');
    var ul2 = document.getElementById('head_ul2');
    var ol = document.getElementById('head_ol');
    //取所有子元素
    var ollis = ol.children;
    //用来控制left
    var leader = 0;
    var target = 0;
    //用来链接头尾
    var leader1 = 576;
    var target2 = 0;
    //计算自动轮播页数
    var intr = 0;
    var intrs = 0;
    //计时器
    var timer = null;
    //重置ul2的位置
    function Reset() {
        ul2.style.left = '576px';
        ul2.style.display = 'none';
        leader1 = 576;
        target2 = 0;

    }
    //遍历ol
    for (var i = 0; i < ollis.length; i++) {
        // 每个li的索引号
        ollis[i].index = i;
        //鼠标悬停事件
        ollis[i].onmouseover = function () {
            //清除计时器
            clearInterval(timer);
            //清除链接ul
            Reset();

            for (var j = 0; j < ollis.length; j++) {
                ollis[j].className = '';//去掉所有的class='current'
            }
            //自动轮播页数同步
            intr = this.index;
            intrs = this.index;
            this.className = 'current';
            target = -this.index * 576;//目标位置=当前index索引号*图片宽度
        }
        ollis[i].onmouseout = function () {
            //重启计时器
            timer = setInterval(autoPlay, 5000);
        }
    }

    //页面加载完成时执行自动轮播
    timer = setInterval(autoPlay, 5000);


    //过度动画
    setInterval(function () {

        if (intr <= 6) {
            leader = leader + (target - leader) / 100;
            ul.style.left = leader + 'px';
        }
        //当页数到达最后的一页时执行
        if (intr > 5) {
            ul2.style.display = 'block';
            leader1 = leader1 + (target2 - leader1) / 100;
            ul2.style.left = leader1 + 'px';
            console.log(intr);
        }
        //链接完成时重置链接ul位置
        if (leader1 < 1) {
            ul.style.left = '0px';
            Reset();
            leader = 0;
            target = 0;
            intr = 0;
            intrs = 0;
        };

    }, 1);

    //自动轮播
    function autoPlay() {
        intr++;
        intrs++;
        //目标位置=当前index索引号*图片宽度    
        target = -intr * 576;
        for (var j = 0; j < ollis.length; j++) {
            ollis[j].className = '';//去掉所有的class='current'
        }
        //当页数到达最大时重置
        if (intrs == ollis.length) {
            intrs = 0;
        }
        //自动轮播页数同步
        ollis[intrs].className = 'current';
    }
}