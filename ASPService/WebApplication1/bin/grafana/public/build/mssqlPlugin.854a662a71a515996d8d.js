(window.webpackJsonp=window.webpackJsonp||[]).push([[69],{QjE0:function(t,e,r){"use strict";var n;r.d(e,"a",(function(){return n})),r.d(e,"c",(function(){return a})),r.d(e,"b",(function(){return o})),function(t){t.Password="password",t.BasicAuthPassword="basicAuthPassword"}(n||(n={}));var a=function(t,e){return function(r){r.preventDefault(),t.current[e]=void 0,t.current.secureJsonFields[e]=!1,t.current.secureJsonData=t.current.secureJsonData||{},t.current.secureJsonData[e]=""}},o=function(t,e){return function(r){t.current.secureJsonData=t.current.secureJsonData||{},t.current.secureJsonData[e]=r.currentTarget.value}}},R57O:function(t,e,r){"use strict";r.r(e);var n=r("LvDl"),a=r.n(n),o=r("F/XL"),i=r("67Y/"),s=r("aGNc"),u=r("9Z1F"),l=r("t8hP");function c(t,e){for(var r=0;r<e.length;r++){var n=e[r];n.enumerable=n.enumerable||!1,n.configurable=!0,"value"in n&&(n.writable=!0),Object.defineProperty(t,n.key,n)}}var f=function(){function t(){!function(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}(this,t)}var e,r,n;return e=t,(r=[{key:"processQueryResult",value:function(t){var e=[];if(!t.data.results)return{data:e};for(var r in t.data.results){var n=t.data.results[r];if(n.series){var a=!0,o=!1,i=void 0;try{for(var s,u=n.series[Symbol.iterator]();!(a=(s=u.next()).done);a=!0){var l=s.value;e.push({target:l.name,datapoints:l.points,refId:n.refId,meta:n.meta})}}catch(t){o=!0,i=t}finally{try{a||null==u.return||u.return()}finally{if(o)throw i}}}if(n.tables){var c=!0,f=!1,m=void 0;try{for(var p,v=n.tables[Symbol.iterator]();!(c=(p=v.next()).done);c=!0){var d=p.value;d.type="table",d.refId=n.refId,d.meta=n.meta,e.push(d)}}catch(t){f=!0,m=t}finally{try{c||null==v.return||v.return()}finally{if(f)throw m}}}}return{data:e}}},{key:"parseMetricFindQueryResult",value:function(t,e){if(!e||0===e.data.length||0===e.data.results[t].meta.rowCount)return[];var r=e.data.results[t].tables[0].columns,n=e.data.results[t].tables[0].rows,a=this.findColIndex(r,"__text"),o=this.findColIndex(r,"__value");return 2===r.length&&-1!==a&&-1!==o?this.transformToKeyValueList(n,a,o):this.transformToSimpleList(n)}},{key:"transformToKeyValueList",value:function(t,e,r){for(var n=[],a=0;a<t.length;a++)this.containsKey(n,t[a][e])||n.push({text:t[a][e],value:t[a][r]});return n}},{key:"transformToSimpleList",value:function(t){for(var e=[],r=0;r<t.length;r++)for(var n=0;n<t[r].length;n++)e.push(t[r][n]);var o=Array.from(new Set(e));return a.a.map(o,(function(t){return{text:t}}))}},{key:"findColIndex",value:function(t,e){for(var r=0;r<t.length;r++)if(t[r].text===e)return r;return-1}},{key:"containsKey",value:function(t,e){for(var r=0;r<t.length;r++)if(t[r].text===e)return!0;return!1}},{key:"transformAnnotationResponse",value:function(t,e){for(var r=e.data.results[t.annotation.name].tables[0],n=-1,a=-1,o=-1,i=-1,s=0;s<r.columns.length;s++)"time"===r.columns[s].text?n=s:"timeend"===r.columns[s].text?a=s:"text"===r.columns[s].text?o=s:"tags"===r.columns[s].text&&(i=s);if(-1===n)return Promise.reject({message:"Missing mandatory time column (with time column alias) in annotation query."});for(var u=[],l=0;l<r.rows.length;l++){var c=r.rows[l],f=-1!==a&&c[a]?Math.floor(c[a]):void 0;u.push({annotation:t.annotation,time:Math.floor(c[n]),timeEnd:f,text:c[o],tags:c[i]?c[i].trim().split(/\s*,\s*/):[]})}return u}}])&&c(e.prototype,r),n&&c(e,n),t}(),m=r("5kRJ"),p=r("NPB1");function v(t,e){var r=Object.keys(t);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(t);e&&(n=n.filter((function(e){return Object.getOwnPropertyDescriptor(t,e).enumerable}))),r.push.apply(r,n)}return r}function d(t,e,r){return e in t?Object.defineProperty(t,e,{value:r,enumerable:!0,configurable:!0,writable:!0}):t[e]=r,t}function h(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}function y(t,e){for(var r=0;r<e.length;r++){var n=e[r];n.enumerable=n.enumerable||!1,n.configurable=!0,"value"in n&&(n.writable=!0),Object.defineProperty(t,n.key,n)}}var b=function(){function t(e){var r=arguments.length>1&&void 0!==arguments[1]?arguments[1]:Object(m.a)(),n=arguments.length>2&&void 0!==arguments[2]?arguments[2]:Object(p.a)();h(this,t),this.templateSrv=r,this.timeSrv=n,this.name=e.name,this.id=e.id,this.responseParser=new f,this.interval=(e.jsonData||{}).timeInterval||"1m"}var e,r,n;return e=t,(r=[{key:"interpolateVariable",value:function(t,e){return"string"==typeof t?e.multi||e.includeAll?"'"+t.replace(/'/g,"''")+"'":t:"number"==typeof t?t:a.a.map(t,(function(e){return"number"==typeof t?t:"'"+e.replace(/'/g,"''")+"'"})).join(",")}},{key:"interpolateVariablesInQueries",value:function(t,e){var r=this,n=t;return t&&t.length>0&&(n=t.map((function(t){return function(t){for(var e=1;e<arguments.length;e++){var r=null!=arguments[e]?arguments[e]:{};e%2?v(Object(r),!0).forEach((function(e){d(t,e,r[e])})):Object.getOwnPropertyDescriptors?Object.defineProperties(t,Object.getOwnPropertyDescriptors(r)):v(Object(r)).forEach((function(e){Object.defineProperty(t,e,Object.getOwnPropertyDescriptor(r,e))}))}return t}({},t,{datasource:r.name,rawSql:r.templateSrv.replace(t.rawSql,e,r.interpolateVariable),rawQuery:!0})}))),n}},{key:"query",value:function(t){var e=this,r=a.a.filter(t.targets,(function(t){return!0!==t.hide})).map((function(r){return{refId:r.refId,intervalMs:t.intervalMs,maxDataPoints:t.maxDataPoints,datasourceId:e.id,rawSql:e.templateSrv.replace(r.rawSql,t.scopedVars,e.interpolateVariable),format:r.format}}));return 0===r.length?Object(o.a)({data:[]}):Object(l.getBackendSrv)().fetch({url:"/api/tsdb/query",method:"POST",data:{from:t.range.from.valueOf().toString(),to:t.range.to.valueOf().toString(),queries:r}}).pipe(Object(i.a)(this.responseParser.processQueryResult))}},{key:"annotationQuery",value:function(t){var e=this;if(!t.annotation.rawQuery)return Promise.reject({message:"Query missing in annotation definition"});var r={refId:t.annotation.name,datasourceId:this.id,rawSql:this.templateSrv.replace(t.annotation.rawQuery,t.scopedVars,this.interpolateVariable),format:"table"};return Object(l.getBackendSrv)().fetch({url:"/api/tsdb/query",method:"POST",data:{from:t.range.from.valueOf().toString(),to:t.range.to.valueOf().toString(),queries:[r]}}).pipe(Object(i.a)((function(r){return e.responseParser.transformAnnotationResponse(t,r)}))).toPromise()}},{key:"metricFindQuery",value:function(t,e){var r=this,n="tempvar";e&&e.variable&&e.variable.name&&(n=e.variable.name);var a={refId:n,datasourceId:this.id,rawSql:this.templateSrv.replace(t,{},this.interpolateVariable),format:"table"},o=this.timeSrv.timeRange(),s={queries:[a],from:o.from.valueOf().toString(),to:o.to.valueOf().toString()};return Object(l.getBackendSrv)().fetch({url:"/api/tsdb/query",method:"POST",data:s}).pipe(Object(i.a)((function(t){return r.responseParser.parseMetricFindQueryResult(n,t)}))).toPromise()}},{key:"testDatasource",value:function(){return Object(l.getBackendSrv)().fetch({url:"/api/tsdb/query",method:"POST",data:{from:"5m",to:"now",queries:[{refId:"A",intervalMs:1,maxDataPoints:1,datasourceId:this.id,rawSql:"SELECT 1",format:"table"}]}}).pipe(Object(s.a)({status:"success",message:"Database Connection OK"}),Object(u.a)((function(t){return console.error(t),t.data&&t.data.message?Object(o.a)({status:"error",message:t.data.message}):Object(o.a)({status:"error",message:t.status})}))).toPromise()}},{key:"targetContainsTemplate",value:function(t){var e=t.rawSql.replace("$__","");return this.templateSrv.variableExists(e)}}])&&y(e.prototype,r),n&&y(e,n),t}(),g=r("LzXI"),w=r("Obii");function O(t){return(O="function"==typeof Symbol&&"symbol"==typeof Symbol.iterator?function(t){return typeof t}:function(t){return t&&"function"==typeof Symbol&&t.constructor===Symbol&&t!==Symbol.prototype?"symbol":typeof t})(t)}function j(t,e){for(var r=0;r<e.length;r++){var n=e[r];n.enumerable=n.enumerable||!1,n.configurable=!0,"value"in n&&(n.writable=!0),Object.defineProperty(t,n.key,n)}}function S(t){return(S=Object.setPrototypeOf?Object.getPrototypeOf:function(t){return t.__proto__||Object.getPrototypeOf(t)})(t)}function P(t){if(void 0===t)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return t}function E(t,e){return(E=Object.setPrototypeOf||function(t,e){return t.__proto__=e,t})(t,e)}var D=function(t){function e(t,r){var n,a,o;return function(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}(this,e),a=this,(n=!(o=S(e).call(this,t,r))||"object"!==O(o)&&"function"!=typeof o?P(a):o).target.format=n.target.format||"time_series",n.target.alias="",n.formats=[{text:"Time series",value:"time_series"},{text:"Table",value:"table"}],n.target.rawSql||("table"===n.panelCtrl.panel.type?(n.target.format="table",n.target.rawSql="SELECT 1"):n.target.rawSql="SELECT\n  $__timeEpoch(<time_column>),\n  <value column> as value,\n  <series name column> as metric\nFROM\n  <table name>\nWHERE\n  $__timeFilter(time_column)\nORDER BY\n  <time_column> ASC"),n.panelCtrl.events.on(w.PanelEvents.dataReceived,n.onDataReceived.bind(P(n)),t),n.panelCtrl.events.on(w.PanelEvents.dataError,n.onDataError.bind(P(n)),t),n}var r,n,a;return e.$inject=["$scope","$injector"],function(t,e){if("function"!=typeof e&&null!==e)throw new TypeError("Super expression must either be null or a function");t.prototype=Object.create(e&&e.prototype,{constructor:{value:t,writable:!0,configurable:!0}}),e&&E(t,e)}(e,t),r=e,(n=[{key:"onDataReceived",value:function(t){var e;this.lastQueryError=void 0,this.lastQueryMeta=null===(e=t[0])||void 0===e?void 0:e.meta}},{key:"onDataError",value:function(t){if(t.data&&t.data.results){var e=t.data.results[this.target.refId];e&&(this.lastQueryError=e.error)}}}])&&j(r.prototype,n),a&&j(r,a),e}(g.QueryCtrl);D.templateUrl="partials/query.editor.html";var _=r("QjE0");function k(t,e){for(var r=0;r<e.length;r++){var n=e[r];n.enumerable=n.enumerable||!1,n.configurable=!0,"value"in n&&(n.writable=!0),Object.defineProperty(t,n.key,n)}}var C=function(){function t(e){!function(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}(this,t),this.current.jsonData.encrypt=this.current.jsonData.encrypt||"false",this.current.jsonData.authenticationType=this.current.jsonData.authenticationType||"SQL Server Authentication",this.onPasswordReset=Object(_.c)(this,_.a.Password),this.onPasswordChange=Object(_.b)(this,_.a.Password),this.showUserCredentials="Windows Authentication"!==this.current.jsonData.authenticationType}var e,r,n;return t.$inject=["$scope"],e=t,(r=[{key:"onAuthenticationTypeChange",value:function(){"Windows Authentication"===this.current.jsonData.authenticationType&&(this.current.user="",this.current.password=""),this.showUserCredentials="Windows Authentication"!==this.current.jsonData.authenticationType}}])&&k(e.prototype,r),n&&k(e,n),t}();C.templateUrl="partials/config.html",r.d(e,"AnnotationsQueryCtrl",(function(){return T})),r.d(e,"MssqlDatasource",(function(){return b})),r.d(e,"Datasource",(function(){return b})),r.d(e,"QueryCtrl",(function(){return D})),r.d(e,"ConfigCtrl",(function(){return C}));var T=function t(){!function(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}(this,t),this.annotation.rawQuery=this.annotation.rawQuery||"SELECT\n    <time_column> as time,\n    <text_column> as text,\n    <tags_column> as tags\n  FROM\n    <table name>\n  WHERE\n    $__timeFilter(time_column)\n  ORDER BY\n    <time_column> ASC"};T.templateUrl="partials/annotations.editor.html"}}]);
//# sourceMappingURL=mssqlPlugin.854a662a71a515996d8d.js.map