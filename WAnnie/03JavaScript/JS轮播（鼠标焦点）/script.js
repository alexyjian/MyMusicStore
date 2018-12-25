window.onload = function(){
    var slider = document.getElementById("slider");
    //取子元素
    var ul = document.getElementById("ad_ul");
    var ol = document.getElementById("ad_ol");

    var ollist = ol.children;

    var leader = 0;
    var target = 0;

    for (var i = 0; i < ollist.length;i++){
        //每个li的索引号
        ollist[i].index = i;
        ollist[i].onmouseover= function(){
            for (var j = 0; j < ollist.length; j++){
                ollist[j].className = "";  //去掉所有的class="current"
            }
            this.className ="current";

            target = -this.index *490;  //目标位置 = 当前index乘以图片宽度
        }
    }

    setInterval(function(){
        leader = leader + (target - leader) / 10;
        ul.style.left = leader + "px";
    },20)
}