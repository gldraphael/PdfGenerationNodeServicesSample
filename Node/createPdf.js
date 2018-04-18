const pdf = require('html-pdf');

/**
 * 
 * @param {stream.Duplex} result 
 * @param {string} html The html string to be converted to PDF
 * @param {*} options Options to be passed to html-pdf
 */
module.exports = function (result, html, options) {
    pdf.create(html, options).toStream(function(err, stream){
        stream.pipe(result.stream);
    });
}; 
