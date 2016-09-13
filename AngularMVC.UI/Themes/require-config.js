require.config({
    baseUrl:"/",
    maps:{},
    waitSeconds: 60,
    paths:{
        jquery:'angular/jquery/jquery-1.12.3.min',
        underscore:'angular/underscore/underscore-min',
        angular:'angular/angular/angular',
        uiRouter:'angular/angular-ui-router/angular-ui-router.min',
        angularAnimate:'angular/angular-animate/angular-animate.min',
        angularTouch:'angular/angular-touch/angular-touch.min',
        angularSanitize:'angular/angular-sanitize/angular-sanitize.min',
        angularResource:'angular/angular-resource/angular-resource',
        angularAria:'angular/angular-aria/angular-aria.min',
        uiBootstrap:'angular/angular-ui-bootstrap/ui-bootstrap-tpls-1.3.2.min',
        bootstrap:'angular/bootstrap/bootstrap.min',
        angularMaterial:'angular/angular-material/angular-material.min',
        angularTranslate:'angular/angular-translate/angular-translate.min',
        angularCookies:'angular/angular-cookies/angular-cookies.min',
       

        text:'angular/require-text/text',
       

        app: 'app/app',
        components: 'app/components/components',
        shared:'app/commons/commons',
      
        ngFileUpload:'angular/ng-file-upload/ng-file-upload',
        validation:'angular/angular-validator/angular-validation',
        validationRule:'angular/angular-validator/angular-validation-rule'


    },
    shim: {
        bootstrap:{
            deps:['jquery']
        },
        angular: {
            deps: ['jquery','bootstrap'],
            exports: 'angular'
        },
        uiRouter: {
            deps: ['angular']
        },
        angularAnimate: {
            deps: ['angular']
        },
        angularTouch: {
            deps: ['angular']
        },
        angularAria: {
            deps: ['angular']
        },
       
        angularCookies: {
            deps: ['angular']
        },
        angularSanitize: {
            deps: ['angular']
        },
        angularResource: {
            deps: ['angular']
        },
        angularTranslate: {
            deps: ['angular']
        },

       
        uiBootstrap:{
            deps:['angularAnimate','angularTouch']
        },
        angularMaterial:{
            deps:['angularAnimate','angularTouch','angularAria']
        },

        app:{

            deps:['angularMaterial','uiRouter','uiBootstrap','angularSanitize',
                'angularResource',
                'angularTranslate','angularCookies',

                'ngFileUpload']

        },
        components:{
            deps:['app']
        },
        shared:{
            deps:['app']
        },
        underscore:{
            exports:'_'
        },
        ngFileUpload:{
            deps:['angular']
        }
    }
});

require(['app'],function(){
    angular.bootstrap(document,['MyApp']);
});
