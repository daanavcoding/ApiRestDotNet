//Si la ruta del puerto cambia debe cambiar esta variable url introduciendo: var url="https://localhost:INTRODUZCA PUERTO AQUÍ/Terminales";
var url = "https://localhost:44326/Terminales";

pintarTabla();

function pintarTabla() {
	fetch(url).then(function (response) {
		return response.json();
    }).then(function (Data) {
        var columnasTabla = [];
        var arrayHeader = ["Nombre del terminal", "Descripción del terminal", "Nombre del fabricante", "Nombre del estado", "Fecha de fabricación", "Fecha de estado","Seleccionar"]
		for (var i = 0; i < Data.length; i++) {
			for (var key in Data[i]) {
                if (columnasTabla.indexOf(key) === -1) {
                    columnasTabla.push(key);
				}
			}
        }        
        var tabla = document.createElement("table");
        tabla.classList.add("table");
        tabla.classList.add("table-striped");
        tabla.classList.add("table-bordered");
        tabla.classList.add("table-hover");
        tabla.setAttribute("id", "tabla");        
        var tr = tabla.insertRow(-1);
        for (var i = 0; i < arrayHeader.length; i++) {
            var th = document.createElement("th");
            document.getElementById("th")
            th.innerHTML = arrayHeader[i];
            tr.appendChild(th);            
        }        
        for (var i = 0; i < Data.length; i++) {
            tr = tabla.insertRow(-1);
            for (var j = 0; j < arrayHeader.length; j++) {
                var tabCell = tr.insertCell(-1);
                if (j!=6)
                    tabCell.innerHTML = Data[i][columnasTabla[j]];
                if (j==6) {                    
                    var chk = document.createElement('input');
                    chk.setAttribute('type', 'checkbox');                    
                    tabCell.appendChild(chk);
                }
            }
        }        
        var divcontainer = document.getElementById("divList");
        divcontainer.innerHTML = "";
        divcontainer.appendChild(tabla);        
    })    
}

function getItemsSeleccionados() {
    var tabla = document.getElementById("tabla");
    var checkBoxes = tabla.getElementsByTagName("input");
    var seleccionadas = [];
    for (var i = 0; i < checkBoxes.length; i++) {
        if (checkBoxes[i].checked) {
            var row = checkBoxes[i].parentNode.parentNode;
            seleccionadas.push(row);
        }
    }
    if (seleccionadas.length == 0) {
        window.alert("Debe seleccionar algún terminal")
    }
    else {
        var terminal = "";
        for (var i = 0; i < seleccionadas.length; i++) {
            terminal += seleccionadas[i].cells[0].innerHTML + ",";
        }
        terminal = terminal.slice(0, -1);
        terminal += "."
        window.alert("Ha seleccionado " + terminal)
    }    
}


