$.fn.extend({
    TxTBoxValidtor: function (reg,msg)
    {       
        var val = $(this).val().trim();
        var id = $(this).attr('id');

      
        if (val != '' && !new RegExp(reg).test(val)) {
            $('#' + id + '_Emsg').remove();
            $(this).after('<span id=' + id + '_Emsg style="color:#ff0000">&nbsp' + msg + '</span>');
            return false;
        } else {
            $('#' + id + '_Emsg').remove();
            return true;
        }
        
    },

    AddWaterMark: function () {
        $(this).blur(function () {
            if (this.value == '') {
                this.value = this.title;
                $(this).addClass("TextboxWatermark");
            }
        });

        $(this).focus(function () {
            if (this.value == this.title) {
                $(this).removeClass("TextboxWatermark");
                this.value = '';
            }
        });

        $(this).blur();
    }
});