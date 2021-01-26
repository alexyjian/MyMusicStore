window.onload = function () {
    var ul = document.getElementById('ad_ul');
    var ol = document.getElementById('ad_ol');

    var ollis = ol.children;
    var time = null;
    var time01=null;
    var leader = 0;
    var target = 0;
    var index1 = 0;
    var olindex = 0;
    for (var i = 0; i < ollis.length; i++) {
        //每个li的索引号
        ollis[i].index = i;
        ollis[i].onmouseover = function () {
            for (var j = 0; j < ollis.length; j++) {
                ollis[j].className = '';   //去掉所有的class='current'
            }
            this.className = 'current';
            index1 = this.index;
            olindex = this.index;
            target = -this.index * 490;  //目标位置=当前index乘以图片宽度
        }
        ollis[i].onmouseout = function () {
            for (var j = 0; j < ollis.length; j++) {
                ollis[j].className = '';   //去掉所有的class='current'
            }
            this.className = 'current';
            index1 = this.index;
            olindex = this.index;
            target = -this.index * 490;  //目标位置=当前index乘以图片宽度
            console.log(olindex)
        }
    }

    time = setInterval(function () {

        for (var j = 0; j < ollis.length; j++) {
            ollis[j].className = '';   //去掉所有的class='current'
        }

        ollis[olindex].className = 'current';
        if (index1 + 1 >= 5) olindex = 0;
        else olindex++;

        target = -index1 * 490;
       
        if (index1 + 1 > 5) {
            target = 0;
            index1 = 0;
            tiem01 = setInterval(move, 10);
        }
        else {
            index1++

        };




    }, 1000)
    //动画 每20ms left的值如何变化
    tiem01 = setInterval(move, 10);
    function move() {
        leader = leader + (target - leader) / 10;
        ul.style.left = leader + 'px';
    }
}