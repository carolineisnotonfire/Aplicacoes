    /* Ao carregar o documento o mesmo inicia o conteudo desde script*/
    jQuery(document).ready(function(){
		/* Indica que o evento submit do form irá realizar esta ação agora*/
		jQuery('#formlivros').submit(function(){
			/* Neste contesto 'this' representa o form deste ID  #myform */                
			var dados = $(this).serialize();

			 var settings = {
			  "crossDomain": true,
			  "url": "http://localhost:59271/Api/Livros",
			  "method": "POST",
			  "headers": {
				"Content-Type": "application/x-www-form-urlencoded",
				"Accept": "*/*"
			  },
			  "data": dados
			}

			$.ajax(settings).done(function (response) {
			    GetMethod(null);
			});
			
			return false;
		});
		
		jQuery('#bntSalvar').click(function(){

			 
			$('#bntSubmit').show();
			$('#bntSalvar').hide();
			$('#bntCancelar').hide();
			
			$('#Id').val("");
			$('#Registro').val("");
			$('#Titulo').val("");
			$('#Isbn').val("");
			$('#Genero').val("");
			$('#Editora').val("");
			$('#Sinopse').val("");
			$('#Observacoes').val("");
			$('#Ativo select').val("true");
		});
		
		jQuery('#bntCancelar').click(function(){
			$('#bntSubmit').show();
			$('#bntSalvar').hide();
			$('#bntCancelar').hide();
			
			$('#Id').val("");
			$('#Registro').val("");
			$('#Titulo').val("");
			$('#Isbn').val("");
			$('#Genero').val("");
			$('#Editora').val("");
			$('#Sinopse').val("");
			$('#Observacoes').val("");
			$('#Ativo select').val("true");
			
		});
          
		
		GetMethod(null);
	});
	
	function GetByID(id){
		$('#bntCancelar').show();
		
        var settings = {
			"async": true,
			"crossDomain": true,
			"url": "http://localhost:59271/Api/Livros/"+id,
			"method": "GET",
				"headers": {
					"Content-Type": "application/json",
					"Accept": "*/*"
				}
			}
	
			$.ajax(settings).done(function (response) {
				$('#Id').val(response.Id);
				$('#Registro').val(response.Registro);
				$('#Titulo').val(response.Titulo);
				$('#Isbn').val(response.Isbn);
				$('#Genero').val(response.Genero);
				$('#Editora').val(response.Editora);
				$('#Sinopse').val(response.Sinopse);
				$('#Observacoes').val(response.Observacoes);
			});
		
	}
    
    function GetMethod(){
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

				$.ajax(settings).done(function (response) {
				  RefrestGrid(response);
				});
			
			return false;
    }
   
    function RefrestGrid(contentValue){
	   $('#tDataGrid').empty();
	   $('#tDataGrid').html(  '<tbody>'
							+ 	'<tr>'
							+ 		'<th>ID                   </th>'
							+ 		'<th>Registro                </th>'
							+ 		'<th>Título                </th>'
							+ 		'<th>Isbn                 </th>'
							+ 		'<th>Gênero                 </th>'
							+ 		'<th>Editora                 </th>'
							+ 		'<th>Sinopse                 </th>'
							+ 		'<th>Observações                 </th>'
							+ 		'<th>Ativo               </th>'
							+ 		'<th>Opções             </th>'
							+ 	'</tr>'
							+ '</tbody>');

		$.each(contentValue,function(index,value) {
        var row =     '<tr>'
						+ '<td>' + value.Id       + '</td>'
						+ '<td>' + value.Registro       + '</td>'
						+ '<td>' + value.Titulo    + '</td>'
						+ '<td>' + value.Isbn    + '</td>'
						+ '<td>' + value.Genero    + '</td>'
						+ '<td>' + value.Editora    + '</td>'
						+ '<td>' + value.Sinopse    + '</td>'
						+ '<td>' + value.Observacoes    + '</td>'
						+ '<td>' + value.Ativo    + '</td>'
						
						+ '<td>' 
						+ 	'<div    class=\'col-md-12\' style=\'float: right;\'>'
						+ 		'<div    class=\'col-md-6\'>'
						+ 			'<button class=\'btn btn-block btn-danger col-md-3 btn-delet-event\' type=\'button\' send-post=\'Livros\'  value=\''+ value.Id +'\'>Remover</button>'
						+ 		'</div>'
						+ 		'<div     class=\'col-md-6\'>'
						+ 			'<button  class=\'btn btn-block btn-success col-md-3 btn-editing-event\' send-post=\'Livros\' value=\''+ value.Id + '\' type=\'button\'\>Editar</button>'
						+ 		'</div>'
						+ 	'</div>'
						+ '</td>'
					+ '</tr>';
        $('#tDataGrid').append(row);
		});
    }
	
	
  
  