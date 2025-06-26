
    //function CountrySelectChange() {
    //    var countryId = document.getElementById("SelectedCountryID-@uniqueId").value;
    //$.ajax({
    //    url: `/Address/GetCities?countryId=${countryId}`,
    //success: function (result) {
    //            var citySelect = document.getElementById("SelectedCityID-@uniqueId");
    //citySelect.innerHTML = "<option value=''>اختر مدينة</option>";

    //for (let city of result) {
    //    citySelect.innerHTML += `<option value="${city.id}">${city.cityName}</option>`;
    //            }

    //// تفريغ الأقضية والأحياء عند تغيير الدولة
    //document.getElementById("SelectedDistrictID-@uniqueId").innerHTML = "<option value=''>اختر قضاء</option>";
    //document.getElementById("SelectedNeighborhoodID-@uniqueId").innerHTML = "<option value=''>اختر حي</option>";
    //        }
    //    });
    //}

    //function CitySelectChange() {
    //    var cityId = document.getElementById("SelectedCityID-@uniqueId").value;
    //$.ajax({
    //    url: `/Address/GetDistricts?CityId=${cityId}`,
    //success: function (result) {
    //            var districtSelect = document.getElementById("SelectedDistrictID-@uniqueId");
    //districtSelect.innerHTML = "<option value=''>اختر قضاء</option>";

    //for (let district of result) {
    //    districtSelect.innerHTML += `<option value="${district.id}">${district.districtName}</option>`;
    //            }

    //// تفريغ الأحياء عند تغيير القضاء
    //document.getElementById("addressPartialView_SelectedNeighborhoodID").innerHTML = "<option value=''>اختر حي</option>";
    //        }
    //    });
    //}

    //function DistrictSelectChange() {
    //    var districtId = document.getElementById("addressPartialView_SelectedDistrictID").value;
    //$.ajax({
    //    url: `/Address/GetNeighborhoods?DistrictId=${districtId}`,
    //method: "GET",
    //success: function (result) {
    //            var neighborhoodSelect = document.getElementById("addressPartialView_SelectedNeighborhoodID");
    //neighborhoodSelect.innerHTML = "<option value=''>اختر حي</option>";

    //for (let neighborhood of result) {
    //    neighborhoodSelect.innerHTML += `<option value="${neighborhood.id}">${neighborhood.neighborhoodName}</option>`;
    //            }
    //        },
    //error: function () {
    //    alert("حدث خطأ أثناء تحميل الأحياء.");
    //        }
    //    });
//}



function loadPartialView(url, targetSelector, prefix = '') {
    $.ajax({
        url: url,
        type: 'GET',
        data: { prefix: prefix },
        success: function (html) {
            $(targetSelector).html(html);
        },
        error: function (xhr, status, error) {
            console.error('Error loading partial view:', error);
        }
    });
}

$(document).ready(function () {

    (function ($) {
        // تسجيل حدث عند تغيير الدولة
        $(document).on('change', '.select-country', function () {
            const uniqueId = $(this).data('unique-id');
            const countryId = $(this).val();

            resetSelect(`.select-city[data-unique-id='${uniqueId}']`, '-- اختر مدينة --');
            resetSelect(`.select-district[data-unique-id='${uniqueId}']`, '-- اختر قضاء --');
            resetSelect(`.select-neighborhood[data-unique-id='${uniqueId}']`, '-- اختر حي --');

            if (!countryId) return;

            $.get(`/Address/GetCities?countryId=${countryId}`, function (cities) {
                populateSelect(`.select-city[data-unique-id='${uniqueId}']`, cities, 'id', 'cityName', '-- اختر مدينة --');
            }).fail(() => alert('حدث خطأ أثناء تحميل المدن.'));
        });

        // تغيير المدينة
        $(document).on('change', '.select-city', function () {
            const uniqueId = $(this).data('unique-id');
            const cityId = $(this).val();

            resetSelect(`.select-district[data-unique-id='${uniqueId}']`, '-- اختر قضاء --');
            resetSelect(`.select-neighborhood[data-unique-id='${uniqueId}']`, '-- اختر حي --');

            if (!cityId) return;

            $.get(`/Address/GetDistricts?cityId=${cityId}`, function (districts) {
                populateSelect(`.select-district[data-unique-id='${uniqueId}']`, districts, 'id', 'districtName', '-- اختر قضاء --');
            }).fail(() => alert('حدث خطأ أثناء تحميل الأقضية.'));
        });

        // تغيير القضاء
        $(document).on('change', '.select-district', function () {
            const uniqueId = $(this).data('unique-id');
            const districtId = $(this).val();

            resetSelect(`.select-neighborhood[data-unique-id='${uniqueId}']`, '-- اختر حي --');

            if (!districtId) return;

            $.get(`/Address/GetNeighborhoods?districtId=${districtId}`, function (neighborhoods) {
                populateSelect(`.select-neighborhood[data-unique-id='${uniqueId}']`, neighborhoods, 'id', 'neighborhoodName', '-- اختر حي --');
            }).fail(() => alert('حدث خطأ أثناء تحميل الأحياء.'));
        });

        // دالة لإعادة تهيئة select
        function resetSelect(selector, placeholder) {
            $(selector).html(`<option value="">${placeholder}</option>`);
        }

        // دالة لملء select بالبيانات
        function populateSelect(selector, data, valueField, textField, placeholder) {
            resetSelect(selector, placeholder);
            if (Array.isArray(data)) {
                data.forEach(item => {
                    $(selector).append(`<option value="${item[valueField]}">${item[textField]}</option>`);
                });
            }
        }
    })(jQuery);
});