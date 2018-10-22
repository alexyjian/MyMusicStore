function fn(canshu1,canshu2){
    var li01 = document.getElementById(canshu1);
    var ul01 = document.getElementById(canshu2);
    
    li01.onmouseover = function(){
        ul01.style.display = "block"    
    }
    li01.onmouseout = function(){
        ul01.style.display = "none"    
    }
}
fn("li01","ul01")    
fn("li02","ul02")    
fn("li03","ul03")