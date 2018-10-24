function change(id,mode){
    document.getElementById(id).style.display=mode;
    if(mode=='block'){
        //设置下拉菜单的边框
        document.getElementById(id).style.border='1px solid #eee';
        document.getElementById(id).style.bordertop='none';

        document.getElementById(id).parentNode.style.backgroundColor='#fff';
        document.getElementById(id).parentNode.style.border='1px solid #eee';
        document.getElementById(id).parentNode.style.borderBottom='none';

    }
    else{
        document.getElementById(id).parentNode.style.backgroundColor='';
        document.getElementById(id).parentNode.style.border='';
    }
}