define(["plugins/http", "durandal/app", "knockout"], function (http, app, ko) {
    var ctor = function () {
        this.displayName = 'Welcome to the Durandal Starter Kit!';
        this.description = 'Durandal is a cross-device, cross-platform client framework written in JavaScript and designed to make Single Page Applications (SPAs) easy to create and maintain.';
        this.myNum;
        this.numList = {};

        var that = this;

        this.resetNum = function() {
            that.myNum = 0;
            that.updateNum(0);
            http.post('/api/Numbers?num=' + that.myNum).then(that.getNum)
        }
        this.postNum = function () {
            that.myNum = that.myNum + 1;
            http.post('/api/Numbers?num=' + that.myNum).then(that.getNum)
            
            
        };
        this.getNum = function () {
            http.get('/api/Numbers').then(function (response) {
                that.numList = response;
                 that.updateNum(that.numList[that.numList.length - 1]);
            });
            
        };
        this.updateNum = function(num) {
            document.getElementById("numTag").textContent = this.myNum;
        };

        this.activate = function() {
            http.get("/api/Numbers/Max").then(function(response) {
                that.myNum = response.number;
            })
        }


        //Note: This module exports a function. That means that you, the developer, can create multiple instances.
        //This pattern is also recognized by Durandal so that it can create instances on demand.
        //If you wish to create a singleton, you should export an object instead of a function.
        //See the "flickr" module for an example of object export.
    }
    return ctor;

});