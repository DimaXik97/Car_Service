module.exports={
    module: {
        loaders: [{
            test: /\.jsx?$/,
            exclude: /(node_modules)/,
            loader: 'babel-loader',
            query: {
                presets: ['es2015', 'react']
            }
        }]
    },
    entry: {
        js: ['babel-polyfill', './src/index.js']
    },
    output: {
        path: __dirname +'./../App_Data/js',
        filename: 'bundle.js'
    },
    watch: true
}