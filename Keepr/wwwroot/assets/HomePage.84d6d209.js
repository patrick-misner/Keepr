import{G as p,g as t,h as _,o as s,c as a,d,F as m,x as i,i as l}from"./vendor.c9635540.js";import{_ as u,k as f,l as v,P as g,A as r}from"./index.f64482bf.js";const k={name:"Home",setup(){return p(async()=>{try{await f.getKeeps()}catch(e){v.error(e),g.toast(e.message,"error")}}),{keeps:t(()=>r.keeps),account:t(()=>r.account)}}},x={class:"container"},y={class:"masonry-frame mt-5"};function h(e,P,B,n,H,K){const c=_("Keep");return s(),a("div",x,[d("div",y,[(s(!0),a(m,null,i(n.keeps,o=>(s(),a("div",{key:o.id,class:"mb-3"},[l(c,{keep:o},null,8,["keep"])]))),128))])])}var j=u(k,[["render",h],["__scopeId","data-v-06fc4dda"]]);export{j as default};
