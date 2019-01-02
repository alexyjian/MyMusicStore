
function jiajianCount(ID,jj) {

    //ajax 提交到服务器端进行购物车项的删除
    $.ajax({
        type: 'post',
        async: true,
        url: '../../ShoppingCart/Modified',
        data: { id: ID, jj: jj },
        dataType: 'json',
        success: function (data) {
            //视图中进行局部页面的刷新 <tbody>
            $("#tbCart").html(data);
        }
    })
}