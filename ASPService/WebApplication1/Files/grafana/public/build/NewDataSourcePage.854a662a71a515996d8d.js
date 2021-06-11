(window.webpackJsonp=window.webpackJsonp||[]).push([[28],{Fofh:function(e,t,n){"use strict";n.r(t),function(e){n.d(t,"getNavModel",(function(){return C}));var a=n("q1tI"),r=n.n(a),o=n("/MKj"),c=n("0cfB"),i=n("kDLi"),u=n("Csm0"),s=n("ZGyg"),l=n("5BCB"),d=n("frIo"),f=n("EKT6"),m=n("FFN/"),p=n("R7n3"),g=n("jcCG"),h=n("xLfX");function b(e){return(b="function"==typeof Symbol&&"symbol"==typeof Symbol.iterator?function(e){return typeof e}:function(e){return e&&"function"==typeof Symbol&&e.constructor===Symbol&&e!==Symbol.prototype?"symbol":typeof e})(e)}function y(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}function v(e,t){for(var n=0;n<t.length;n++){var a=t[n];a.enumerable=a.enumerable||!1,a.configurable=!0,"value"in a&&(a.writable=!0),Object.defineProperty(e,a.key,a)}}function E(e,t){return!t||"object"!==b(t)&&"function"!=typeof t?function(e){if(void 0===e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return e}(e):t}function k(e){return(k=Object.setPrototypeOf?Object.getPrototypeOf:function(e){return e.__proto__||Object.getPrototypeOf(e)})(e)}function S(e,t){return(S=Object.setPrototypeOf||function(e,t){return e.__proto__=t,e})(e,t)}var j=function(e){function t(){var e,n;y(this,t);for(var a=arguments.length,r=new Array(a),o=0;o<a;o++)r[o]=arguments[o];return(n=E(this,(e=k(t)).call.apply(e,[this].concat(r)))).onDataSourceTypeClicked=function(e){n.props.addDataSource(e)},n.onSearchQueryChange=function(e){n.props.setDataSourceTypeSearchQuery(e)},n.onLearnMoreClick=function(e){e.stopPropagation()},n}var n,a,o;return function(e,t){if("function"!=typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function");e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,writable:!0,configurable:!0}}),t&&S(e,t)}(t,e),n=t,(a=[{key:"componentDidMount",value:function(){this.props.loadDataSourcePlugins()}},{key:"renderPlugins",value:function(e){var t=this;return e&&e.length?r.a.createElement(i.List,{items:e,getItemKey:function(e){return e.id.toString()},renderItem:function(e){return r.a.createElement(w,{plugin:e,onClick:function(){return t.onDataSourceTypeClicked(e)},onLearnMoreClick:t.onLearnMoreClick})}}):null}},{key:"renderCategories",value:function(){var e=this,t=this.props.categories;return r.a.createElement(r.a.Fragment,null,t.map((function(t){return r.a.createElement("div",{className:"add-data-source-category",key:t.id},r.a.createElement("div",{className:"add-data-source-category__header"},t.title),e.renderPlugins(t.plugins))})),r.a.createElement("div",{className:"add-data-source-more"},r.a.createElement(i.LinkButton,{variant:"secondary",href:"https://grafana.com/plugins?type=datasource&utm_source=grafana_add_ds",target:"_blank",rel:"noopener"},"Find more data source plugins on grafana.com")))}},{key:"render",value:function(){var e=this.props,t=e.navModel,n=e.isLoading,a=e.searchQuery,o=e.plugins;return r.a.createElement(s.a,{navModel:t},r.a.createElement(s.a.Contents,{isLoading:n},r.a.createElement("div",{className:"page-action-bar"},r.a.createElement(f.a,{value:a,onChange:this.onSearchQueryChange,placeholder:"Filter by name or type"}),r.a.createElement("div",{className:"page-action-bar__spacer"}),r.a.createElement(i.LinkButton,{href:"datasources"},"Cancel")),!a&&r.a.createElement(h.a,null,r.a.createElement(r.a.Fragment,null,r.a.createElement("br",null),r.a.createElement("p",null,"Note that ",r.a.createElement("strong",null,"unsigned front-end datasource plugins")," are still usable, but this is subject to change in the upcoming releases of Grafana"))),r.a.createElement("div",null,a&&this.renderPlugins(o),!a&&this.renderCategories())))}}])&&v(n.prototype,a),o&&v(n,o),t}(a.PureComponent),w=function(e){var t,n,a=e.plugin,o=e.onLearnMoreClick,c="phantom"===a.module,s=c||a.unlicensed?function(){}:e.onClick,l=(null===(t=a.info)||void 0===t||null===(n=t.links)||void 0===n?void 0:n.length)>0?a.info.links[0]:null;return r.a.createElement(g.a,{title:a.name,description:a.info.description,ariaLabel:u.selectors.pages.AddDataSource.dataSourcePlugins(a.name),logoUrl:a.info.logos.small,actions:r.a.createElement(r.a.Fragment,null,l&&r.a.createElement(i.LinkButton,{variant:"secondary",href:"".concat(l.url,"?utm_source=grafana_add_ds"),target:"_blank",rel:"noopener",onClick:o,icon:"external-link-alt"},l.name),!c&&r.a.createElement(i.Button,{disabled:a.unlicensed},"Select")),labels:!c&&r.a.createElement(p.a,{status:a.signature}),className:c?"add-data-source-item--phantom":"",onClick:s,"aria-label":u.selectors.pages.AddDataSource.dataSourcePlugins(a.name)})};function C(){var e={icon:"database",id:"datasource-new",text:"Add data source",href:"datasources/new",subTitle:"Choose a data source type"};return{main:e,node:e}}var O={addDataSource:l.a,loadDataSourcePlugins:l.e,setDataSourceTypeSearchQuery:m.j};t.default=Object(c.hot)(e)(Object(o.connect)((function(e){return{navModel:C(),plugins:Object(d.c)(e.dataSources),searchQuery:e.dataSources.dataSourceTypeSearchQuery,categories:e.dataSources.categories,isLoading:e.dataSources.isLoadingDataSources}}),O)(j))}.call(this,n("3UD+")(e))},jcCG:function(e,t,n){"use strict";n.d(t,"a",(function(){return c}));var a=n("q1tI"),r=n.n(a),o=n("kDDq"),c=function(e){var t=e.logoUrl,n=e.title,a=e.description,c=e.labels,i=e.actions,u=e.onClick,s=e.ariaLabel,l=e.className,d=Object(o.cx)("add-data-source-item",l);return r.a.createElement("div",{className:d,onClick:u,"aria-label":s},t&&r.a.createElement("img",{className:"add-data-source-item-logo",src:t}),r.a.createElement("div",{className:"add-data-source-item-text-wrapper"},r.a.createElement("span",{className:"add-data-source-item-text"},n),a&&r.a.createElement("span",{className:"add-data-source-item-desc"},a),c&&r.a.createElement("div",{className:"add-data-source-item-badge"},c)),i&&r.a.createElement("div",{className:"add-data-source-item-actions"},i))}},xLfX:function(e,t,n){"use strict";(function(e){n.d(t,"a",(function(){return S}));var a=n("q1tI"),r=n.n(a),o=n("Csm0"),c=n("kDLi"),i=n("R7n3"),u=n("y6t6"),s=n("jGYO"),l=n("aBYM"),d=n.n(l),f=n("/MKj"),m=n("0cfB"),p=n("kDDq");function g(){var e=y(["\n                    margin-top: 0;\n                  "]);return g=function(){return e},e}function h(){var e=y(["\n                margin-top: ",";\n              "]);return h=function(){return e},e}function b(){var e=y(["\n            list-style-type: circle;\n          "]);return b=function(){return e},e}function y(e,t){return t||(t=e.slice(0)),Object.freeze(Object.defineProperties(e,{raw:{value:Object.freeze(t)}}))}function v(e,t,n,a,r,o,c){try{var i=e[o](c),u=i.value}catch(e){return void n(e)}i.done?t(u):Promise.resolve(u).then(a,r)}function E(e){return function(){var t=this,n=arguments;return new Promise((function(a,r){var o=e.apply(t,n);function c(e){v(o,a,r,c,i,"next",e)}function i(e){v(o,a,r,c,i,"throw",e)}c(void 0)}))}}var k={loadPluginsErrors:s.d},S=Object(m.hot)(e)(Object(f.connect)((function(e){return{errors:Object(u.a)(e.plugins)}}),k)((function(e){var t=e.loadPluginsErrors,n=e.errors,a=e.children,u=Object(c.useTheme)();return d()(E(regeneratorRuntime.mark((function e(){return regeneratorRuntime.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return e.next=2,t();case 2:case"end":return e.stop()}}),e)}))),[s.c]).loading||0===n.length?null:r.a.createElement(c.InfoBox,{"aria-label":o.selectors.pages.PluginsList.signatureErrorNotice,severity:"warning",urlTitle:"Read more about plugin signing",url:"https://grafana.com/docs/grafana/latest/plugins/plugin-signatures/"},r.a.createElement("div",null,r.a.createElement("p",null,"We have encountered"," ",r.a.createElement("a",{href:"https://grafana.com/docs/grafana/latest/developers/plugins/backend/",target:"_blank",rel:"noreferrer"},"data source backend plugins")," ","that are unsigned. Grafana Labs cannot guarantee the integrity of unsigned plugins and recommends using signed plugins only."),"The following plugins are disabled and not shown in the list below:",r.a.createElement(c.List,{items:n,className:Object(p.css)(b()),renderItem:function(e){return r.a.createElement("div",{className:Object(p.css)(h(),u.spacing.sm)},r.a.createElement(c.HorizontalGroup,{spacing:"sm",justify:"flex-start",align:"center"},r.a.createElement("strong",null,e.pluginId),r.a.createElement(i.a,{status:Object(i.c)(e.errorCode),className:Object(p.css)(g())})))}}),a))})))}).call(this,n("3UD+")(e))},y6t6:function(e,t,n){"use strict";n.d(t,"b",(function(){return a})),n.d(t,"a",(function(){return r})),n.d(t,"c",(function(){return o}));var a=function(e){var t=new RegExp(e.searchQuery,"i");return e.plugins.filter((function(e){return t.test(e.name)||t.test(e.info.author.name)||t.test(e.info.description)}))},r=function(e){return e.errors},o=function(e){return e.searchQuery}}}]);
//# sourceMappingURL=NewDataSourcePage.854a662a71a515996d8d.js.map