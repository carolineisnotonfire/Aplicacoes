var livroList;
var usuarioList;

  /* Ao carregar o documento o mesmo inicia o conteudo desde script*/
jQuery(document).ready(function(){
    var settings = {
        "async": true,
        "crossDomain": true,
        "url": "http://localhost:59271/Api/Livros",
        "method": "GET",
        "headers": {
            "Content-Type": "application/json",
            "Accept": "*/*"
          }
        }
//tradução de gênero
        $.ajax(settings).done(function (response) {
            livroList = response;

            $.each(response,function(index,value){
                $('#Livro')[0].innerHTML += '<option value=\''+ value.Id +'\'>'+ value.Tipo +'</option>';
            });
        });

        settings = {
        "async": true,
        "crossDomain": true,
        "url": "http://localhost:59271/Api/Usuarios",
        "method": "GET",
        "headers": {
            "Content-Type": "application/json",
            "Accept": "*/*"
          }
        }
    //tradução de usuario
        $.ajax(settings).done(function (response) {
            usuarioList = response;

            $.each(response,function(index,value){
                $('#Usuario')[0].innerHTML += '<option value=\''+ value.Id +'\'>'+ value.Nome +'</option>';
            });
        });

        GetMethod(null);
});

function GetByID(id){
	//$('#bntSubmit').hide();
	//$('#bntSalvar').show();
	$('#bntCancelar').show();
	
	var settings = {
		"async": true,
		"crossDomain": true,
		"url": "http://localhost:59271/Api/Locacaos/"+id,
		"method": "GET",
			"headers": {
				"Content-Type": "application/json",
				"Accept": "*/*"
			}
		}

		$.ajax(settings).done(function (response) {
			$('#Id').val(response.Id);
            $('#Livro').val(response.Livro);
            $('#Usuário').val(response.Usuario);
            $('#Devolução').val(response.Devolucao);
            $('#Ativo select').val("true");
		});
	
}

    
function GetMethod(object){
	var settings = {
		"async": true,
		"crossDomain": true,
		"url": "http://localhost:59271/Api/Locacaos",
		"method": "GET",
		"headers": {
			"Content-Type": "application/json",
			"Accept": "*/*"
		  }
		}

		$.ajax(settings).done(function (response) {
		  RefreshGrid(response);
		});
	
	return false;
}

function RefreshGrid(contentValue){
   $('#tDataGrid').empty();
   $('#tDataGrid').html(  '<tbody>'
						+ 	'<tr>'
                        + 		'<th>ID</th>'
                        + 		'<th>Livro</th>'
                        + 		'<th>Usuário</th>'
                        + 		'<th>Devolução</th>'
						+ 		'<th>Ativo</th>'
						+ 		'<th>Opções</th>'
						+ 	'</tr>'
						+ '</tbody>');

	$.each(contentValue,function(index,value) {
	var row =     '<tr>'
					+ '<td>' + value.Id       + '</td>'
					+ '<td>' + value.Livro     + '</td>'
					+ '<td>' + value.Usuario + '</td>'
                    + '<td>' + value.Devolucao     + '</td>'
                    + '<td>' + value.Ativo     + '</td>'
					+ '<td>' 
					+ 	'<div    class=\'col-md-12\' style=\'float: right;\'>'
					+ 		'<div    class=\'col-md-6\'>'
					+ 			'<button class=\'btn btn-block btn-danger col-md-3 btn-delet-event\' type=\'button\' send-post=\'Locacaos\'  value=\''+ value.Id +'\'>Remover</button>'
					+ 		'</div>'
					+ 		'<div     class=\'col-md-6\'>'
					+ 			'<button  class=\'btn btn-block btn-success col-md-3 btn-editing-event\' send-post=\'Locacaos\' value=\''+ value.Id + '\' type=\'button\'\>Editar</button>'
					+ 		'</div>'
					+ 	'</div>'
					+ '</td>'
				+ '</tr>';
	$('#tDataGrid').append(row);
	});
	SetGridClickEvents();

}
