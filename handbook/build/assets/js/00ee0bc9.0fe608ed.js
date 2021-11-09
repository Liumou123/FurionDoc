"use strict";(self.webpackChunkfurion=self.webpackChunkfurion||[]).push([[6792],{3905:function(e,t,n){n.d(t,{Zo:function(){return d},kt:function(){return m}});var r=n(7294);function o(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function i(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function a(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?i(Object(n),!0).forEach((function(t){o(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):i(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function l(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},i=Object.keys(e);for(r=0;r<i.length;r++)n=i[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(r=0;r<i.length;r++)n=i[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}var c=r.createContext({}),p=function(e){var t=r.useContext(c),n=t;return e&&(n="function"==typeof e?e(t):a(a({},t),e)),n},d=function(e){var t=p(e.components);return r.createElement(c.Provider,{value:t},e.children)},u={inlineCode:"code",wrapper:function(e){var t=e.children;return r.createElement(r.Fragment,{},t)}},s=r.forwardRef((function(e,t){var n=e.components,o=e.mdxType,i=e.originalType,c=e.parentName,d=l(e,["components","mdxType","originalType","parentName"]),s=p(n),m=o,k=s["".concat(c,".").concat(m)]||s[m]||u[m]||i;return n?r.createElement(k,a(a({ref:t},d),{},{components:n})):r.createElement(k,a({ref:t},d))}));function m(e,t){var n=arguments,o=t&&t.mdxType;if("string"==typeof e||o){var i=n.length,a=new Array(i);a[0]=s;var l={};for(var c in t)hasOwnProperty.call(t,c)&&(l[c]=t[c]);l.originalType=e,l.mdxType="string"==typeof e?e:o,a[1]=l;for(var p=2;p<i;p++)a[p]=n[p];return r.createElement.apply(null,a)}return r.createElement.apply(null,n)}s.displayName="MDXCreateElement"},7173:function(e,t,n){n.r(t),n.d(t,{frontMatter:function(){return c},contentTitle:function(){return p},metadata:function(){return d},toc:function(){return u},default:function(){return m}});var r=n(3117),o=n(102),i=(n(7294),n(3905)),a=n(4996),l=["components"],c={id:"net5-to-net6",title:"2.5 .NET5 \u5347\u7ea7 .NET6",sidebar_label:"2.5 .NET5 \u5347\u7ea7 .NET6 \u2728"},p=void 0,d={unversionedId:"net5-to-net6",id:"net5-to-net6",isDocsHomePage:!1,title:"2.5 .NET5 \u5347\u7ea7 .NET6",description:"2.5.1 \u5347\u7ea7\u6ce8\u610f\u4e8b\u9879",source:"@site/docs/net5-to-net6.mdx",sourceDirName:".",slug:"/net5-to-net6",permalink:"/furion/docs/net5-to-net6",editUrl:"https://gitee.com/dotnetchina/Furion/tree/master/handbook/docs/net5-to-net6.mdx",tags:[],version:"current",frontMatter:{id:"net5-to-net6",title:"2.5 .NET5 \u5347\u7ea7 .NET6",sidebar_label:"2.5 .NET5 \u5347\u7ea7 .NET6 \u2728"},sidebar:"docs",previous:{title:"2.4 \u795e\u5947\u7684 Inject",permalink:"/furion/docs/inject"},next:{title:"3. \u5e94\u7528\u542f\u52a8 Startup",permalink:"/furion/docs/appstartup"}},u=[{value:"2.5.1 \u5347\u7ea7\u6ce8\u610f\u4e8b\u9879",id:"251-\u5347\u7ea7\u6ce8\u610f\u4e8b\u9879",children:[{value:"2.5.1.1 \u5b89\u88c5 <code>.NET6 SDK</code>",id:"2511-\u5b89\u88c5-net6-sdk",children:[],level:3},{value:"2.5.1.2 \u7f16\u8f91 <code>.csproj</code> \u6587\u4ef6",id:"2512-\u7f16\u8f91-csproj-\u6587\u4ef6",children:[],level:3},{value:"2.5.1.3 \u5347\u7ea7 <code>Nuget</code> \u5305",id:"2513-\u5347\u7ea7-nuget-\u5305",children:[],level:3},{value:"2.5.1.4 \u5220\u9664 <code>Startup.cs</code> \u6587\u4ef6",id:"2514-\u5220\u9664-startupcs-\u6587\u4ef6",children:[],level:3},{value:"2.5.1.5 \u7f16\u8f91 <code>Web</code> \u542f\u52a8\u5c42 <code>.csproj</code>",id:"2515-\u7f16\u8f91-web-\u542f\u52a8\u5c42-csproj",children:[],level:3},{value:"2.5.1.6 \u66ff\u6362 <code>Program.cs</code> \u5185\u5bb9\u4e3a\uff1a",id:"2516-\u66ff\u6362-programcs-\u5185\u5bb9\u4e3a",children:[],level:3},{value:"2.5.1.7 \u91cd\u65b0\u7f16\u8bd1\u6574\u4e2a\u89e3\u51b3\u65b9\u6848",id:"2517-\u91cd\u65b0\u7f16\u8bd1\u6574\u4e2a\u89e3\u51b3\u65b9\u6848",children:[],level:3}],level:2}],s={toc:u};function m(e){var t=e.components,n=(0,o.Z)(e,l);return(0,i.kt)("wrapper",(0,r.Z)({},s,n,{components:t,mdxType:"MDXLayout"}),(0,i.kt)("h2",{id:"251-\u5347\u7ea7\u6ce8\u610f\u4e8b\u9879"},"2.5.1 \u5347\u7ea7\u6ce8\u610f\u4e8b\u9879"),(0,i.kt)("p",null,(0,i.kt)("strong",{parentName:"p"},"\u76ee\u524d\u4f7f\u7528 ",(0,i.kt)("inlineCode",{parentName:"strong"},"Furion v2.x")," \u7248\u672c\u7684\u7528\u6237\u5747\u53ef\u4ee5\u5feb\u901f\u65e0\u7f1d\u5347\u7ea7\u81f3 ",(0,i.kt)("inlineCode",{parentName:"strong"},"Furion v3.x")," \u7248\u672c\uff0c\u53ea\u9700\u8981\u505a\u5c11\u91cf\u66f4\u6539\u5373\u53ef\u3002")),(0,i.kt)("h3",{id:"2511-\u5b89\u88c5-net6-sdk"},"2.5.1.1 \u5b89\u88c5 ",(0,i.kt)("inlineCode",{parentName:"h3"},".NET6 SDK")),(0,i.kt)("p",null,(0,i.kt)("a",{parentName:"p",href:"https://dotnet.microsoft.com/download/dotnet/6.0"},"https://dotnet.microsoft.com/download/dotnet/6.0")),(0,i.kt)("h3",{id:"2512-\u7f16\u8f91-csproj-\u6587\u4ef6"},"2.5.1.2 \u7f16\u8f91 ",(0,i.kt)("inlineCode",{parentName:"h3"},".csproj")," \u6587\u4ef6"),(0,i.kt)("p",null,"\u7f16\u8f91\u89e3\u51b3\u65b9\u6848\u6240\u6709\u9879\u76ee\u7684 ",(0,i.kt)("inlineCode",{parentName:"p"},".csproj")," \u6587\u4ef6\uff0c\u5e76\u66ff\u6362 ",(0,i.kt)("inlineCode",{parentName:"p"},"<TargetFramework>net5.0</TargetFramework>")," \u4e3a ",(0,i.kt)("inlineCode",{parentName:"p"},"<TargetFramework>net6.0</TargetFramework>"),"\uff0c\u5982\uff1a"),(0,i.kt)("img",{src:(0,a.Z)("img/sjl1.png")}),(0,i.kt)("p",null,"\u5f53\u7136\u4e5f\u53ef\u4ee5\u4f7f\u7528 ",(0,i.kt)("inlineCode",{parentName:"p"},"Ctrl + F")," \u5168\u5c40\u66ff\u6362"),(0,i.kt)("img",{src:(0,a.Z)("img/sjl2.png")}),(0,i.kt)("h3",{id:"2513-\u5347\u7ea7-nuget-\u5305"},"2.5.1.3 \u5347\u7ea7 ",(0,i.kt)("inlineCode",{parentName:"h3"},"Nuget")," \u5305"),(0,i.kt)("p",null,"\u5c06 ",(0,i.kt)("inlineCode",{parentName:"p"},"Furion")," \u6240\u6709\u5305\u5347\u7ea7\u81f3 ",(0,i.kt)("inlineCode",{parentName:"p"},"v3.0.0")," \u7248\u672c\uff0c\u540c\u65f6 ",(0,i.kt)("inlineCode",{parentName:"p"},"Microsoft")," \u6240\u6709\u5305\u5347\u7ea7\u81f3 ",(0,i.kt)("inlineCode",{parentName:"p"},"v6.0.0")," \u7248\u672c\uff0c\u5982\uff1a"),(0,i.kt)("img",{src:(0,a.Z)("img/sjl3.png")}),(0,i.kt)("h3",{id:"2514-\u5220\u9664-startupcs-\u6587\u4ef6"},"2.5.1.4 \u5220\u9664 ",(0,i.kt)("inlineCode",{parentName:"h3"},"Startup.cs")," \u6587\u4ef6"),(0,i.kt)("p",null,"\u5220\u9664 ",(0,i.kt)("inlineCode",{parentName:"p"},"Web \u542f\u52a8\u5c42")," \u7684 ",(0,i.kt)("inlineCode",{parentName:"p"},"Startup.cs")," \u6587\u4ef6\uff0c\u5982\uff1a"),(0,i.kt)("img",{src:(0,a.Z)("img/sjl4.png")}),(0,i.kt)("h3",{id:"2515-\u7f16\u8f91-web-\u542f\u52a8\u5c42-csproj"},"2.5.1.5 \u7f16\u8f91 ",(0,i.kt)("inlineCode",{parentName:"h3"},"Web")," \u542f\u52a8\u5c42 ",(0,i.kt)("inlineCode",{parentName:"h3"},".csproj")),(0,i.kt)("p",null,"\u7f16\u8f91 ",(0,i.kt)("inlineCode",{parentName:"p"},"Web")," \u542f\u52a8\u5c42 ",(0,i.kt)("inlineCode",{parentName:"p"},".csproj")," \u6587\u4ef6\uff0c\u5e76\u6dfb\u52a0 ",(0,i.kt)("inlineCode",{parentName:"p"},"<ImplicitUsings>enable</ImplicitUsings>"),"\uff0c\u5982\uff1a"),(0,i.kt)("img",{src:(0,a.Z)("img/sjl5.png")}),(0,i.kt)("h3",{id:"2516-\u66ff\u6362-programcs-\u5185\u5bb9\u4e3a"},"2.5.1.6 \u66ff\u6362 ",(0,i.kt)("inlineCode",{parentName:"h3"},"Program.cs")," \u5185\u5bb9\u4e3a\uff1a"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-cs"},"var builder = WebApplication.CreateBuilder(args).Inject();\nvar app = builder.Build();\napp.Run();\n")),(0,i.kt)("img",{src:(0,a.Z)("img/sjl6.png")}),(0,i.kt)("h3",{id:"2517-\u91cd\u65b0\u7f16\u8bd1\u6574\u4e2a\u89e3\u51b3\u65b9\u6848"},"2.5.1.7 \u91cd\u65b0\u7f16\u8bd1\u6574\u4e2a\u89e3\u51b3\u65b9\u6848"),(0,i.kt)("p",null,"\u5347\u7ea7\u5b8c\u6210\uff01\uff01\uff01"))}m.isMDXComponent=!0}}]);