(self.webpackChunkfurion=self.webpackChunkfurion||[]).push([[3089,4224],{3905:function(e,t,a){"use strict";a.d(t,{Zo:function(){return m},kt:function(){return d}});var r=a(7294);function n(e,t,a){return t in e?Object.defineProperty(e,t,{value:a,enumerable:!0,configurable:!0,writable:!0}):e[t]=a,e}function l(e,t){var a=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),a.push.apply(a,r)}return a}function o(e){for(var t=1;t<arguments.length;t++){var a=null!=arguments[t]?arguments[t]:{};t%2?l(Object(a),!0).forEach((function(t){n(e,t,a[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(a)):l(Object(a)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(a,t))}))}return e}function i(e,t){if(null==e)return{};var a,r,n=function(e,t){if(null==e)return{};var a,r,n={},l=Object.keys(e);for(r=0;r<l.length;r++)a=l[r],t.indexOf(a)>=0||(n[a]=e[a]);return n}(e,t);if(Object.getOwnPropertySymbols){var l=Object.getOwnPropertySymbols(e);for(r=0;r<l.length;r++)a=l[r],t.indexOf(a)>=0||Object.prototype.propertyIsEnumerable.call(e,a)&&(n[a]=e[a])}return n}var c=r.createContext({}),s=function(e){var t=r.useContext(c),a=t;return e&&(a="function"==typeof e?e(t):o(o({},t),e)),a},m=function(e){var t=s(e.components);return r.createElement(c.Provider,{value:t},e.children)},u={inlineCode:"code",wrapper:function(e){var t=e.children;return r.createElement(r.Fragment,{},t)}},p=r.forwardRef((function(e,t){var a=e.components,n=e.mdxType,l=e.originalType,c=e.parentName,m=i(e,["components","mdxType","originalType","parentName"]),p=s(a),d=n,g=p["".concat(c,".").concat(d)]||p[d]||u[d]||l;return a?r.createElement(g,o(o({ref:t},m),{},{components:a})):r.createElement(g,o({ref:t},m))}));function d(e,t){var a=arguments,n=t&&t.mdxType;if("string"==typeof e||n){var l=a.length,o=new Array(l);o[0]=p;var i={};for(var c in t)hasOwnProperty.call(t,c)&&(i[c]=t[c]);i.originalType=e,i.mdxType="string"==typeof e?e:n,o[1]=i;for(var s=2;s<l;s++)o[s]=a[s];return r.createElement.apply(null,o)}return r.createElement.apply(null,a)}p.displayName="MDXCreateElement"},4428:function(e,t,a){"use strict";a.r(t),a.d(t,{default:function(){return p}});var r=a(7294),n=a(2263),l=a(9045),o=a(3146),i=a(6742),c=a(4973);var s=function(e){var t=e.metadata,a=t.previousPage,n=t.nextPage;return r.createElement("nav",{className:"pagination-nav","aria-label":(0,c.I)({id:"theme.blog.paginator.navAriaLabel",message:"Blog list page navigation",description:"The ARIA label for the blog pagination"})},r.createElement("div",{className:"pagination-nav__item"},a&&r.createElement(i.Z,{className:"pagination-nav__link",to:a},r.createElement("div",{className:"pagination-nav__label"},"\xab"," ",r.createElement(c.Z,{id:"theme.blog.paginator.newerEntries",description:"The label used to navigate to the newer blog posts page (previous page)"},"Newer Entries")))),r.createElement("div",{className:"pagination-nav__item pagination-nav__item--next"},n&&r.createElement(i.Z,{className:"pagination-nav__link",to:n},r.createElement("div",{className:"pagination-nav__label"},r.createElement(c.Z,{id:"theme.blog.paginator.olderEntries",description:"The label used to navigate to the older blog posts page (next page)"},"Older Entries")," ","\xbb"))))},m=a(5601),u=a(6700);var p=function(e){var t=e.metadata,a=e.items,i=e.sidebar,c=(0,n.default)().siteConfig.title,p=t.blogDescription,d=t.blogTitle,g="/"===t.permalink?c:d;return r.createElement(l.Z,{title:g,description:p,wrapperClassName:u.kM.wrapper.blogPages,pageClassName:u.kM.page.blogListPage,searchMetadatas:{tag:"blog_posts_list"}},r.createElement("div",{className:"container margin-vert--lg"},r.createElement("div",{className:"row"},r.createElement("div",{className:"col col--3"},r.createElement(m.Z,{sidebar:i})),r.createElement("main",{className:"col col--7"},a.map((function(e){var t=e.content;return r.createElement(o.Z,{key:t.metadata.permalink,frontMatter:t.frontMatter,metadata:t.metadata,truncated:t.metadata.truncated},r.createElement(t,null))})),r.createElement(s,{metadata:t})))))}},3146:function(e,t,a){"use strict";a.d(t,{Z:function(){return d}});var r=a(7294),n=a(6010),l=a(3905),o=a(4973),i=a(6742),c=a(3541),s=a(1217),m="blogPostTitle_GeHD",u="blogPostDate_fNvV",p=a(6700);var d=function(e){var t,a,d=(t=(0,p.c2)().selectMessage,function(e){var a=Math.ceil(e);return t(a,(0,o.I)({id:"theme.blog.post.readingTime.plurals",description:'Pluralized label for "{readingTime} min read". Use as much plural forms (separated by "|") as your language support (see https://www.unicode.org/cldr/cldr-aux/charts/34/supplemental/language_plural_rules.html)',message:"One min read|{readingTime} min read"},{readingTime:a}))}),g=e.children,f=e.frontMatter,v=e.metadata,E=e.truncated,b=e.isBlogPostPage,h=void 0!==b&&b,_=v.date,N=v.formattedDate,y=v.permalink,k=v.tags,Z=v.readingTime,w=f.author,O=f.title,T=f.image,P=f.keywords,x=f.author_url||f.authorURL,j=f.author_title||f.authorTitle,L=f.author_image_url||f.authorImageURL;return r.createElement(r.Fragment,null,r.createElement(s.Z,{keywords:P,image:T}),r.createElement("article",{className:h?void 0:"margin-bottom--xl"},(a=h?"h1":"h2",r.createElement("header",null,r.createElement(a,{className:(0,n.Z)("margin-bottom--sm",m)},h?O:r.createElement(i.Z,{to:y},O)),r.createElement("div",{className:"margin-vert--md"},r.createElement("time",{dateTime:_,className:u},N,Z&&r.createElement(r.Fragment,null," \xb7 ",d(Z)))),r.createElement("div",{className:"avatar margin-vert--md"},L&&r.createElement(i.Z,{className:"avatar__photo-link avatar__photo",href:x},r.createElement("img",{src:L,alt:w})),r.createElement("div",{className:"avatar__intro"},w&&r.createElement(r.Fragment,null,r.createElement("h4",{className:"avatar__name"},r.createElement(i.Z,{href:x},w)),r.createElement("small",{className:"avatar__subtitle"},j)))))),r.createElement("div",{className:"markdown"},r.createElement(l.Zo,{components:c.Z},g)),(k.length>0||E)&&r.createElement("footer",{className:"row margin-vert--lg"},k.length>0&&r.createElement("div",{className:"col"},r.createElement("strong",null,r.createElement(o.Z,{id:"theme.tags.tagsListLabel",description:"The label alongside a tag list"},"Tags:")),k.map((function(e){var t=e.label,a=e.permalink;return r.createElement(i.Z,{key:a,className:"margin-horiz--sm",to:a},t)}))),E&&r.createElement("div",{className:"col text--right"},r.createElement(i.Z,{to:v.permalink,"aria-label":"Read more about "+O},r.createElement("strong",null,r.createElement(o.Z,{id:"theme.blog.post.readMore",description:"The label used in blog post item excerpts to link to full blog posts"},"Read More")))))))}},5601:function(e,t,a){"use strict";a.d(t,{Z:function(){return p}});var r=a(7294),n=a(6010),l=a(6742),o="sidebar_2ahu",i="sidebarItemTitle_2hhb",c="sidebarItemList_2xAf",s="sidebarItem_2UVv",m="sidebarItemLink_1RT6",u="sidebarItemLinkActive_12pM";function p(e){var t=e.sidebar;return 0===t.items.length?null:r.createElement("div",{className:(0,n.Z)(o,"thin-scrollbar")},r.createElement("h3",{className:i},t.title),r.createElement("ul",{className:c},t.items.map((function(e){return r.createElement("li",{key:e.permalink,className:s},r.createElement(l.Z,{isNavLink:!0,to:e.permalink,className:m,activeClassName:u},e.title))}))))}},546:function(e,t,a){"use strict";a.d(t,{Z:function(){return d}});var r=a(4034),n=a(9973),l=a(7294),o=a(6010),i=a(6742),c=a(6700),s=a(4996),m="footerLogoLink_qW4Z";function u(e){var t=e.to,a=e.href,o=e.label,c=e.prependBaseUrlToHref,m=(0,n.Z)(e,["to","href","label","prependBaseUrlToHref"]),u=(0,s.Z)(t),p=(0,s.Z)(a,{forcePrependBaseUrl:!0});return l.createElement(i.Z,(0,r.Z)({className:"footer__link-item"},a?{target:"_blank",rel:"noopener noreferrer",href:c?p:a}:{to:u},m),o)}var p=function(e){var t=e.url,a=e.alt;return l.createElement("img",{className:"footer__logo",alt:a,src:t,style:{background:"#fff",padding:"5px 10px"}})};var d=function(){var e=(0,c.LU)().footer,t=e||{},a=t.copyright,r=t.links,n=void 0===r?[]:r,i=t.logo,d=void 0===i?{}:i,g=(0,s.Z)(d.src);return e?l.createElement("footer",{className:(0,o.Z)("footer",{"footer--dark":"dark"===e.style})},l.createElement("div",{className:"container"},n&&n.length>0&&l.createElement("div",{className:"row footer__links"},n.map((function(e,t){return l.createElement("div",{key:t,className:"col footer__col"},null!=e.title?l.createElement("h4",{className:"footer__title"},e.title):null,null!=e.items&&Array.isArray(e.items)&&e.items.length>0?l.createElement("ul",{className:"footer__items"},e.items.map((function(e,t){return e.html?l.createElement("li",{key:t,className:"footer__item",dangerouslySetInnerHTML:{__html:e.html}}):l.createElement("li",{key:e.href||e.to,className:"footer__item"},l.createElement(u,e))}))):null)}))),(d||a)&&l.createElement("div",{className:"footer__bottom text--center"},d&&d.src&&l.createElement("div",{className:"margin-bottom--sm"},d.href?l.createElement("a",{href:d.href,target:"_blank",rel:"noopener noreferrer",className:m},l.createElement(p,{alt:d.alt,url:g})):l.createElement(p,{alt:d.alt,url:g})),a?l.createElement("div",{className:"footer__copyright",dangerouslySetInnerHTML:{__html:a}}):null))):null}}}]);