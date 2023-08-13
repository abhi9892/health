import { Navbar, ScrollArea, Title, createStyles, rem, useMantineTheme } from "@mantine/core";
import React from "react"
import { RouteComponentProps } from "react-router";
import { projectJson } from "./project";
import { LinksGroup } from "./NavbarLinksGroup/NavbarLinksGroup";

const useStyles = createStyles((theme) => ({
    navbar: {
        backgroundColor: theme.colorScheme === 'dark' ? theme.colors.dark[6] : theme.white,
        paddingBottom: 0,
    },

    header: {
        padding: theme.spacing.md,
        paddingTop: 0,
        marginLeft: `calc(${theme.spacing.md} * -1)`,
        marginRight: `calc(${theme.spacing.md} * -1)`,
        color: theme.colorScheme === 'dark' ? theme.white : theme.black,
        borderBottom: `${rem(1)} solid ${theme.colorScheme === 'dark' ? theme.colors.dark[4] : theme.colors.gray[3]
            }`,
    },

    links: {
        marginLeft: `calc(${theme.spacing.md} * -1)`,
        marginRight: `calc(${theme.spacing.md} * -1)`,
    },

    linksInner: {
        paddingTop: theme.spacing.xs,
        paddingBottom: theme.spacing.xl,
    },

    footer: {
        marginLeft: `calc(${theme.spacing.md} * -1)`,
        marginRight: `calc(${theme.spacing.md} * -1)`,
        borderTop: `${rem(1)} solid ${theme.colorScheme === 'dark' ? theme.colors.dark[4] : theme.colors.gray[3]
            }`,
    },
}));

export const Nav: React.FC<any> = (props: any) => {
    const { classes } = useStyles();
    const theme = useMantineTheme();

    let navmenu: any = projectJson.health.navMenu;



    const links = navmenu.map((item: any) => <LinksGroup history={props.history} {...item} key={item.label} setIsHovered={props.setIsHovered} />)

    return (
        <React.Fragment>
            <Navbar height="100vh"
                width={{ sm: 320 }} p="md" className={classes.navbar}
                bg={theme.colorScheme === 'dark' ? theme.colors.dark[6] : theme.fn.darken(theme.fn.primaryColor(), 0.8)}>
                <Navbar.Section grow className={classes.links} component={ScrollArea}>
                    <Title
                        align="left"
                        sx={(theme) => ({ fontFamily: `Greycliff CF, ${theme.fontFamily}`, fontWeight: 900 })}
                        order={2}
                        c={theme.primaryColor}
                    >
                        Health
                    </Title>
                    <div className={classes.linksInner}>{links}</div>
                </Navbar.Section>
            </Navbar>
        </React.Fragment>
    )
}