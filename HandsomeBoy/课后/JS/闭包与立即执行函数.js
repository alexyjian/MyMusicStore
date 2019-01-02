// function  a(){
//     var num = 100;
//     function b(){
//         num++;
//         console.log(num);
//     }
//     b();
// }
// var demo = a();
// demo();
// demo();



function test(){
    var arr = [];
    for(var i=0;i<10;i++)
    {
        // 立即执行函数
     ( function (j){
        arr[j] = function()
        {
            document.write(j+" ")
        }
    }(i)
     )
}
    return arr;
//   闭包
}
var myarr = test();
for(var j=0;j<10;j++)
{
   myarr[j]();
}
