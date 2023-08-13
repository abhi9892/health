import { useEffect, useState } from 'react';
import { Group, Box, Collapse, Text, UnstyledButton, createStyles, rem, useMantineTheme } from '@mantine/core';
import { IconChevronLeft, IconChevronRight } from '@tabler/icons-react';

const useStyles = createStyles((theme) => ({
  control: {
    fontWeight: 500,
    display: 'block',
    width: '100%',
    padding: `${theme.spacing.xs} ${theme.spacing.md}`,
    color: theme.colorScheme === 'dark' ? theme.colors.dark[0] : theme.colors[theme.primaryColor][0],
    fontSize: theme.fontSizes.sm,
    marginTop: rem(10),
    borderRadius: '0',
    '&:hover': {
      backgroundColor: theme.colorScheme === 'dark' ? theme.colors.dark[7] : theme.colors[theme.primaryColor][8],
      color: theme.colorScheme === 'dark' ? theme.white : theme.colors[theme.primaryColor][2],
    },
  },

  link: {
    fontWeight: 500,
    display: 'block',
    textDecoration: 'none',
    padding: `${theme.spacing.xs} ${theme.spacing.md}`,
    paddingLeft: rem(31),
    marginLeft: rem(30),
    fontSize: theme.fontSizes.sm,
    color: theme.colorScheme === 'dark' ? theme.colors.dark[0] : theme.colors[theme.primaryColor][0],
    borderLeft: `${rem(1)} solid ${theme.colorScheme === 'dark' ? theme.colors.dark[4] : theme.colors.gray[3]
      }`,

    '&:hover': {
      backgroundColor: theme.colorScheme === 'dark' ? theme.colors.dark[7] : theme.colors[theme.primaryColor][6],
      color: theme.colorScheme === 'dark' ? theme.white : theme.colors[theme.primaryColor][2],
    },
    cursor: 'pointer'
  },

  chevron: {
    transition: 'transform 200ms ease',
  },
}));

interface LinksGroupProps {
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  icon: React.FC<any>;
  label: string;
  initiallyOpened?: boolean;
  link: string;
  links?: { label: string; link: string }[];
}

export const LinksGroup = (props: any) => {
  const { icon: Icon, label, initiallyOpened, link, links }: LinksGroupProps = props
  const { history } = props;
  const { classes, theme } = useStyles();
  const hasLinks = Array.isArray(links);
  const [opened, setOpened] = useState(initiallyOpened || false);
  const ChevronIcon = theme.dir === 'ltr' ? IconChevronRight : IconChevronLeft;
  const items = (hasLinks ? links : []).map((link, i) => (
    <Text
      component="a"
      className={classes.link}
      key={i}
      onClick={() => {
        // props.setIsHovered(false)
        history.push(`${link.link}`)
      }}
    >
      {link.label}
    </Text>
  ));
  const theme1 = useMantineTheme();

  return (
    <>
      <UnstyledButton onClick={() => setOpened((o: any) => !o)} className={classes.control}>
        <Group position="apart" spacing={0} onClick={() => {
          // props.setIsHovered(false)
          history.push(`${link}`)
        }}>

          <Box sx={{ display: 'flex', alignItems: 'center' }}>

            <Box w={200} ml="md">
              {label}
            </Box>
          </Box>

          {hasLinks && (
            <ChevronIcon
              className={classes.chevron}
              size="1rem"
              stroke={1.5}
              style={{
                transform: opened ? `rotate(${theme.dir === 'rtl' ? -90 : 90}deg)` : 'none',
              }}
            />
          )}

          {/* <ThemeIcon variant="light" size={30} color={theme1.primaryColor }> */}
          <Icon size="1.4rem" color={theme1.colors[theme1.primaryColor][2]} />
          {/* </ThemeIcon> */}

        </Group>

      </UnstyledButton >

      {hasLinks ? <Collapse in={opened}> {items}</Collapse > : null
      }
    </>
  );
};