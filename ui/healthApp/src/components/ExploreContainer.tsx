import { Button, Container,Paper } from "@mantine/core";

export const ExploreContainer = () => {
  return (
    <>
      <Container size={420} my={40}>
      <Paper withBorder shadow="md" p={30} mt={30} radius="md">
        <Button>Hello world</Button>
        </Paper>
      </Container>
    </>
  );
};