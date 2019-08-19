  /* Ao carregar o documento o mesmo inicia o conteudo desde script*/
  jQuery(document).ready(function(){
	
	jQuery('#bntSalvar').click(function(){
		 
		$('#bntSubmit').show();
		$('#bntSalvar').hide();
		$('#bntCancelar').hide();
		
        $('#Id').val(response.Id);
        $('#Livro').val(response.Livro);
        $('#Usuário').val(response.Usuario);
        $('#Tipo').val(response.Tipo);
        $('#Devolução').val(response.Devolucao);
        $('#Tipo').val(response.Tipo);
        $('#Ativo select').val("true");
	});
	
	jQuery('#bntCancelar').click(function(){
		$('#bntSubmit').show();
		$('#bntSalvar').hide();
		$('#bntCancelar').hide();
		
        $('#Id').val(response.Id);
        $('#Livro').val(response.Livro);
        $('#Usuário').val(response.Usuario);
        $('#Tipo').val(response.Tipo);
        $('#Devolução').val(response.Devolucao);
        $('#Tipo').val(response.Tipo);
        $('#Ativo select').val("true");
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
            $('#Tipo').val(response.Tipo);
            $('#Devolução').val(response.Devolucao);
            $('#Tipo').val(response.Tipo);
            $('#Ativo select').val("true");
		});
	
}

function Deleting(id){
		 var settings = {
		  "crossDomain": true,
		  "url": "http://localhost:59271/Api/Locacaos/"+id,
		  "method": "DELETE",
		  "headers": {
			"Content-Type": "application/x-www-form-urlencoded",
			"Accept": "*/*"
		  }
		}

		$.ajax(settings).done(function (response) {
			GetMethod(null);
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
						+ 		'<th>Tipo</th>'
                        + 		'<th>Devolução</th>'
                        + 		'<th>Tipo</th>'
						+ 		'<th>Ativo</th>'
						+ 		'<th>Opções</th>'
						+ 	'</tr>'
						+ '</tbody>');

	$.each(contentValue,function(index,value) {
	var row =     '<tr>'
					+ '<td>' + value.Id       + '</td>'
					+ '<td>' + value.Livro     + '</td>'
					+ '<td>' + value.Usuario + '</td>'
                    + '<td>' + value.Tipo    + '</td>'
                    + '<td>' + value.Devolucao     + '</td>'
                    + '<td>' + value.Tipo     + '</td>'
                    + '<td>' + value.Ativo     + '</td>'
					+ '<td>' 
					+ 	'<div    class=\'col-md-12\' style=\'float: right;\'>'
					+ 		'<div    class=\'col-md-6\'>'
					+ 			'<button class=\'btn btn-block btn-danger col-md-3 ajax\' type=\'button\'  onclick=\'Deleting('+ value.Id +')\'>Remover</button>'
					+ 		'</div>'
					+ 		'<div     class=\'col-md-6\'>'
					+ 			'<button  class=\'btn btn-block btn-success col-md-3\'    type=\'button\'  onclick=\'GetByID('+ value.Id +')\'\>Editar</button>'
					+ 		'</div>'
					+ 	'</div>'
					+ '</td>'
				+ '</tr>';
	$('#tDataGrid').append(row);
	});
}
