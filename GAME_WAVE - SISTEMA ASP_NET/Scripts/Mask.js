//cpf mask
function MaskCpf(obj) {
    if (obj.value.length == 3 || obj.value.length == 7) {
        obj.value = obj.value + ".";
    }

    if (obj.value.length == 11) {
        obj.value = obj.value + "-";
    }
}

function MaskCep(obj) {
    if (obj.value.length == 5) {
        obj.value = obj.value + "-";
    }
}

//telefone mask
function MaskTel(obj) {
    if (obj.value.length == 0) {
        obj.value = obj.value + "(";
    }

    if (obj.value.length == 3) {
        obj.value = obj.value + ")";
    }

    if (obj.value.length == 9) {
        obj.value = obj.value + "-";
    }
}

//date
function MaskDate(obj) {
    if (obj.value.length == 2 || obj.value.length == 5) {
        obj.value = obj.value + "/";
    }

}


//cep
function MaskCep(obj) {
    if (obj.value.length == 5) {
        obj.value = obj.value + "-";
    }

}