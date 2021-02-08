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

function ShowCriterias() {
    $('#partial-view').toggle();
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