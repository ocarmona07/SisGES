<%@ Page Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SisGES.Vista.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <section id="content" class="clearfix">
        <!-- Title -->
        <div id="content-title">Inicio</div>
        <br />

        <!-- BEGIN TILE CONTENT -->
        <section id="content-mos" class="centered clearfix">
            <!-- Tile 1 -->
            <a href="#article-1" class="lightbox" rel="section">
                <div class="tile large live" data-stops="0,25%,50%,75%,100%" data-speed="3000" data-delay="0" data-direction="horizontal" data-stack="true">
                    <div class="live-front">
                        <img class="live-img" src="images/placeholder/large_blank.png" alt="Article 1" />
                    </div>
                    <div class="live-back">
                        <img class="live-img" src="images/placeholder/large_blank.png" alt="Article 1" />
                    </div>
                    <span class="tile-date redtxt"><span class="date">17</span><span class="month">Octubre</span></span>
                    <span class="tile-cat red">Capacitación Sename</span>
                </div>
            </a>
            <!-- Lightbox Article Preview -->
            <div class="tile-pre">
                <article id="article-1" class="lb-article">
                    <div class="article-img">
                        <div class="flexslider postslide">
                            <ul class="slides">
                                <li>
                                    <img class="tile-pre-img" src="images/placeholder/blog_pre_blank_1.jpg" alt="Cap 1" />
                                </li>
                                <li>
                                    <img class="tile-pre-img" src="images/placeholder/blog_pre_blank_2.jpg" alt="Cap 2" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="article-date redtxt"><span class="date">17</span><span class="month">Octubre</span></div>
                    <h1 class="lb-title">Capacitación Sename</h1>
                    <span class="postcat redtxt">Mujeres jefas de hogar</span>
                    <div class="lb-excerpt">
                        <p>Recuerden confirmar la asistencia de sus familias asignadas.
                            La lista se debe entregar antes de la fecha publicada.
                            Esta debe llevar el RUT, nombre, apellido y un télefono de contacto.</p>
                    </div>
                </article>
            </div>

            <!-- Tile 2 -->
            <a href="#article-2" class="lightbox" rel="section">
                <div class="tile medium live" data-stops="0,75%,100%" data-speed="750" data-delay="1500">
                    <div class="live-front">
                        <img class="live-img" src="images/placeholder/medium_blank.png" alt="Article 2" />
                    </div>
                    <div class="live-back">
                        <img class="live-img" src="images/placeholder/medium_blank.png" alt="Article 2" />
                    </div>
                    <span class="tile-date limetxt"><span class="date">27</span><span class="month">Octubre</span></span>
                    <span class="tile-cat lime">Reunión Fosis</span>
                </div>
            </a>
            <!-- Lightbox Article Preview -->
            <div class="tile-pre">
                <article id="article-2" class="lb-article">
                    <div class="article-img">
                        <div class="flexslider postslide">
                            <ul class="slides">
                                <li>
                                    <img class="tile-pre-img" src="images/placeholder/medium_blank_1.jpg" alt="Reunion 1" />
                                </li>
                                <li>
                                    <img class="tile-pre-img" src="images/placeholder/medium_blank_2.jpg" alt="Reunion 2" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="article-date limetxt"><span class="date">27</span><span class="month">Octubre</span></div>
                    <h1 class="lb-title">This is the title of Article Two</h1>
                    <span class="postcat limetxt">Cartoon Design</span>
                    <div class="lb-excerpt">
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam sagittis sollicitudin aliquet. Nullam ut sapien eros, aliquet gravida turpis. Cras nec risus magna. Morbi laoreet molestie odio sed ultrices. Maecenas eget elit orci. Etiam rhoncus urna vitae neque accumsan et vehicula dolor varius. Praesent tellus velit.</p>
                        <p><a class="exp-button" href="singleblogpost-1.html">Read More &#8594;</a></p>
                    </div>
                </article>
            </div>

            <!-- Tile 3 -->
            <div class="tile small live exclude" data-stops="0,100%" data-speed="1000" data-delay="1500">
                <div class="live-front mango">
                    <span class="tile-text">Revisa tu correo siempre</span>
                </div>
                <div class="live-back green">
                    <span class="tile-text">Cumple con los horarios acordados</span>
                </div>
            </div>

            <!-- Tile 4 -->
            <a href="#portfolio-2" class="lightbox" rel="section">
                <div class="tile small">
                    <img class="live-img" src="images/placeholder/small_blank.png" alt="Project Two" />
                </div>
            </a>
            <!-- Lightbox Article Preview -->
            <div class="tile-pre">
                <article id="portfolio-2" class="lb-portfolio">
                    <div class="portfolio-img">
                        <img class="tile-pre-img" src="images/placeholder/portfolio_pre_blank.png" alt="Project Two" />
                    </div>
                    <div class="lb-port-cont">
                        <h1 class="lb-project"><a href="singleportfolio.html">Project Two</a></h1>
                        <span class="projectcat tealtxt">Graphic Design</span>
                        <div class="lb-desc">
                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam sagittis sollicitudin aliquet. Nullam ut sapien eros, aliquet gravida turpis. Cras nec risus magna. Morbi laoreet molestie odio sed ultrices. Maecenas eget elit orci. Etiam rhoncus urna vitae neque accumsan et vehicula dolor varius. Praesent tellus velit.</p>
                            <p><a class="exp-button" href="singleportfolio.html">View More &#8594;</a></p>
                        </div>
                    </div>
                </article>
            </div>

            <!-- Tile 5 -->
            <a href="#portfolio-3" class="lightbox" rel="section">
                <div class="tile small">
                    <img class="live-img" src="images/placeholder/small_blank.png" alt="Project Three" />
                </div>
            </a>
            <!-- Lightbox Article Preview -->
            <div class="tile-pre">
                <article id="portfolio-3" class="lb-portfolio">
                    <div class="portfolio-img">
                        <img class="tile-pre-img" src="images/placeholder/portfolio_pre_blank.png" alt="Project Three" />
                    </div>
                    <div class="lb-port-cont">
                        <h1 class="lb-project"><a href="singleportfolio.html">Project Three</a></h1>
                        <span class="projectcat redtxt">Illustration</span>
                        <div class="lb-desc">
                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam sagittis sollicitudin aliquet. Nullam ut sapien eros, aliquet gravida turpis. Cras nec risus magna. Morbi laoreet molestie odio sed ultrices. Maecenas eget elit orci. Etiam rhoncus urna vitae neque accumsan et vehicula dolor varius. Praesent tellus velit.</p>
                            <p><a class="exp-button" href="singleportfolio.html">View More &#8594;</a></p>
                        </div>
                    </div>
                </article>
            </div>

            <!-- Tile 6 -->
            <a href="#quotation-1" class="lightbox" rel="section">
                <div class="tile small live" data-mode="flip" data-stops="100%" data-speed="750" data-delay="4000">
                    <div class="live-front">
                        <img class="live-img" src="images/articles/quotation_1.png" alt="Quotation" />
                    </div>
                    <div class="live-back">
                        <img class="live-img" src="images/articles/quotation_2.png" alt="Quotation" />
                    </div>
                </div>
            </a>
            <!-- Lightbox Article Preview -->
            <div class="tile-pre">
                <article id="quotation-1" class="lb-article">
                    <div class="lb-quote">
                        Recuerden que los ingresos se deben realizar antes del 27 de cada mes
                        <div class="quote-author">&mdash; Leonor Seguel</div>
                    </div>
                </article>
            </div>

            <!-- Tile 7 -->
            <a href="#portfolio-4" class="lightbox" rel="section">
                <div class="tile small">
                    <img class="live-img" src="images/placeholder/small_blank.png" alt="Project Four" />
                </div>
            </a>
            <!-- Lightbox Article Preview -->
            <div class="tile-pre">
                <article id="portfolio-4" class="lb-portfolio">
                    <div class="portfolio-img">
                        <img class="tile-pre-img" src="images/placeholder/portfolio_pre_blank.png" alt="Project Four" />
                    </div>
                    <div class="lb-port-cont">
                        <h1 class="lb-project"><a href="singleportfolio.html">Project Four</a></h1>
                        <span class="projectcat tealtxt">Graphic Design</span>
                        <div class="lb-desc">
                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam sagittis sollicitudin aliquet. Nullam ut sapien eros, aliquet gravida turpis. Cras nec risus magna. Morbi laoreet molestie odio sed ultrices. Maecenas eget elit orci. Etiam rhoncus urna vitae neque accumsan et vehicula dolor varius. Praesent tellus velit.</p>
                            <p><a class="exp-button" href="singleportfolio.html">View More &#8594;</a></p>
                        </div>
                    </div>
                </article>
            </div>

            <!-- Tile 5 -->
            <a href="http://www.ministeriodesarrollosocial.gob.cl/">
                <div class="tile small live" data-stack="true" data-stops="0,100%" data-speed="750" data-delay="2500">
                    <div class="live-front mango">
                        <img class="live-img" src="images/articles/mindessoc.jpg" alt="HTML5 Icon" />
                    </div>
                    <div class="live-back red">
                        <img class="live-img" src="images/hyperlink.png" alt="Hyperlink Icon" />
                    </div>
                </div>
            </a>

            <!-- END TILE CONTENT -->
        </section>
        <br />
        <div id="content-title2"></div>
        <!-- end #content-mos -->
    </section>
</asp:Content>
