import{_ as c,d as i,k as m,l as p,P as _,b as s,A as r,r as l,o as a,c as t,a as v,F as f,e as u,f as h}from"./index.f054cde9.js";const g={name:"Home",setup(){return i(async()=>{try{await m.getKeeps()}catch(e){p.error(e),_.toast(e.message,"error")}}),{keeps:s(()=>r.keeps),account:s(()=>r.account)}}},y={class:"container"},k={class:"masonry-frame mt-5"};function x(e,b,w,d,P,B){const n=l("Keep");return a(),t("div",y,[v("div",k,[(a(!0),t(f,null,u(d.keeps,o=>(a(),t("div",{key:o.id,class:"mb-3"},[h(n,{keep:o},null,8,["keep"])]))),128))])])}var K=c(g,[["render",x],["__scopeId","data-v-06fc4dda"]]);export{K as default};