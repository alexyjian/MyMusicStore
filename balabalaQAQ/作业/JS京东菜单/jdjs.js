/* var one =document.getElementById('inlist');
var zz =document.getElementById('div_drop');
//事件
//悬停
one.onmouseover=function(){
   zz.style.display='block';
   one.style.background='white';
}
console.log(one);
//离开
one.onmouseout=function(){
   zz.style.display='none';
   one.style.background='glay';
} */
//id传入的控件id，mode变换的属性值
function change(id,mode){
    document.getElementById(id).style.display=mode;
    if(mode=='block'){
        //设置下拉菜单的边框
        document.getElementById(id).style.borderTop='none';
        //设置显示下拉菜单时，鼠标划过LI的效果
        document.getElementById(id).parentNode.style.backgroundColor='#fff';
        document.getElementById(id).parentNode.style.borderBottom='none';
    }
    else{
        //不显示下拉菜单时 鼠标划过LI的效果
        document.getElementById(id).parentNode.style.backgroundColor='rgb(247,247,247)';
        document.getElementById(id).parentNode.style.border='none';
    }
}