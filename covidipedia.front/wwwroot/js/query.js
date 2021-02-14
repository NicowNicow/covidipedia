$(document).ready(function() {
    try {
        $.noConflict();
        $('#results-table').DataTable({
            language: {
                url: "https://cdn.datatables.net/plug-ins/1.10.22/i18n/French.json"
            }
        })
    }
    catch {}
});

window.onload = function() {
    var currentDate = new Date().toISOString().split("T")[0];
    var list = document.querySelectorAll(".input-date");
    for (var index=0; index < list.length; index++) {
        list[index].max = currentDate;
        if (list[index].classList.contains('input-maximum')) {
            list[index].value = currentDate;
        }
    }
};


function ShowCriterias() {
    $('#partial-view').toggle();
}

function FillEmptyRequired() { //TODO: Y'a un problème avec les input-number maximum, ils se resetent constament au max
    const inputList = document.querySelectorAll(".input-number, .input-date");
    for (let index = 0; index < inputList.length; index++) {
        if (((inputList[index].value == null) || (inputList[index].value < inputList[index].min)) && (inputList[index].classList.contains('input-minimum'))) {
            inputList[index].value = inputList[index].min;
        }
        else if (((inputList[index].value == null) || (inputList[index].value > inputList[index].max))  && (inputList[index].classList.contains('input-maximum'))) {
            inputList[index].value = inputList[index].max;
        }
    }
}

if ( $('[type="date"]').prop('type') != 'date' ) {
    $('[type="date"]').datepicker();
}

window.addEventListener("load", ChangeAdvancedCriteriaForm(document.getElementById("select-table").value), false);

function ChangeAdvancedCriteriaForm(selector) {
    $('#no-main-criteria').attr('hidden', '');
    $('#criteria-cas-personne').attr('hidden', '');
    $('#criteria-effets-secondaires').attr('hidden', '');
    $('#criteria-historique').attr('hidden', '');
    $('#criteria-hopital').attr('hidden', '');
    $('#criteria-localisation').attr('hidden', '');
    $('#criteria-pathologie').attr('hidden', '');
    $('#criteria-symptome').attr('hidden', '');
    $('#criteria-traitement').attr('hidden', '');
    $('#criteria-vaccin').attr('hidden', '');
    switch (selector) {
        case 'Cas':
        case 'Personne':
            $('#criteria-cas-personne').removeAttr('hidden');
            break;
        
        case 'EffetsSecondaires':
            $('#criteria-effets-secondaires').removeAttr('hidden');
            break;

        case 'Historique':
            $('#criteria-historique').removeAttr('hidden');
            break;
        
        case 'Hopital':
            $('#criteria-hopital').removeAttr('hidden');
            break;
        
        case 'Localisation':
            $('#criteria-localisation').removeAttr('hidden');
            break;
        
        case 'Pathologie':
            $('#criteria-pathologie').removeAttr('hidden');
            break;
        
        case 'Symptome':
            $('#criteria-symptome').removeAttr('hidden');
            break;
        
        case 'Traitement':
            $('#criteria-traitement').removeAttr('hidden');
            break;
        
        case 'Vaccin':
            $('#criteria-vaccin').removeAttr('hidden');
            break;
            
        default:
            $('#no-main-criteria').removeAttr('hidden');
            break;
    }
}