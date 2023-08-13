import { useEffect, useState } from "react";
import { ColorSchemeProvider, ColorScheme, MantineProvider, Flex, useMantineTheme } from '@mantine/core';
import { IonApp, IonButton, IonIcon, IonLabel, IonRouterOutlet, IonTabBar, IonTabButton, setupIonicReact } from "@ionic/react";
import { IonReactRouter } from "@ionic/react-router";
import { Redirect, Route } from "react-router";

import Home from "../pages/Home";
import { Admin } from "../pages/Admin";
import { Doctor } from "../pages/Doctor";
import { Patient } from "../pages/Patient";
import { Nav } from "../nav/Nav";
import "../App.css"


setupIonicReact();

export const BaseRoute = () => {
    const [colorScheme, setColorScheme] = useState<ColorScheme>("dark");
    const toggleColorScheme = (value?: ColorScheme) => setColorScheme(value || (colorScheme === 'dark' ? 'light' : 'dark'));
    const [isHovered, setIsHovered] = useState(false);
    const handleMouseEnter = () => {
        setIsHovered(true);
    };

    const handleMouseLeave = () => {
        setIsHovered(false);
    };

    return (
        <ColorSchemeProvider colorScheme={colorScheme} toggleColorScheme={toggleColorScheme}>
            <MantineProvider withGlobalStyles withNormalizeCSS theme={{ colorScheme: colorScheme, primaryColor: "pink" }}>
                <IonApp>
                    <IonReactRouter>
                        <IonRouterOutlet>
                            <div>{isHovered ? "Open" : "Close"}</div>
                            <Flex>
                                <div className="sidenav"
                                    style={{
                                        left: isHovered ? '0px' : '-260px',
                                        // backgroundColor: "#fff",
                                        // transition: '0.3s',
                                        // height: '100vh',
                                        // width: '260px',
                                        // position: 'fixed',
                                        // top: '0',
                                        // zIndex: '111',
                                        // overflowX: 'hidden'
                                    }}
                                    onMouseEnter={handleMouseEnter}
                                    onMouseLeave={handleMouseLeave}
                                >
                                    <Route render={props => <Nav  {...props} setIsHovered={setIsHovered} />}></Route>
                                </div>
                                <Route exact path="/home" render={props => <Home  {...props} />}></Route>
                                <Route exact path="/admin" render={props => <Admin  {...props} />}></Route>
                                <Route exact path="/doctor" render={props => <Doctor  {...props} />}></Route>
                                <Route exact path="/patient" render={props => <Patient  {...props} />}></Route>

                                <Route exact path="/">
                                    <Redirect to="/doctor" />
                                </Route>
                            </Flex>
                        </IonRouterOutlet>

                    </IonReactRouter>
                </IonApp>
            </MantineProvider>
        </ColorSchemeProvider>
    );

}

