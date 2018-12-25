//ID传入的控件ID，mode变换的属性值
function change(id,mode){
    document.getElementById(id).style.display= mode;
    
    if(mode=="block"){
        //设置下拉菜单的边框
        document.getElementById(id).style.border='2px solid #fff';
        document.getElementById(id).style.borderTop='none';

        //设置 显示 下拉菜单时，鼠标划过 li 的效果
        document.getElementById(id).parentNode.style.backgroundColor='#fff';
        document.getElementById(id).parentNode.style.border='2px solid #eee';
        document.getElementById(id).parentNode.style.borderBottom='none';

    }
    else{
        // 不显示 下拉菜单时，鼠标划过 li 的效果
        document.getElementById(id).parentNode.style.backgroundColor='';
        document.getElementById(id).parentNode.style.border='';
    }

}