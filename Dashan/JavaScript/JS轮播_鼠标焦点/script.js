window.onload = function(){
    var ul = document.getElementById('sv_ul');
    var ol = document.getElementById('sv_ol');

    var ollis = ol.children;

    var leader = 0;
    var target =0 ;
    for(var i=0; i<ollis.length;i++){
        //li索引号
        ollis[i].index = i;
        ollis[i].onmouseover = function(){
            for(var j=0;j<ollis.length;j++){
                ollis[j].className='';//去掉所有的class=‘current’
            }
            this.className='current';//目标位置current = 当前index * 图片宽度
            target=-this.index*490;
        }
    }

    //动画 每20ms 毫秒 left值得变化
    setInterval(function(){
        leader = leader + (target - leader)/10;
        ul.style.left = leader + 'px';
    },20)
}