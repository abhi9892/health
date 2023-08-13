import { IonContent, IonHeader, IonPage, IonTitle, IonToolbar } from '@ionic/react';
import { Button, Container, Paper } from "@mantine/core";
import { useState } from 'react';
import { RouteComponentProps } from 'react-router';

export const Doctor:React.FC<RouteComponentProps>= () => {
  const [title, setTitle] = useState<string>();

  const onclick = () => {
    setTitle("Hi Doctor here");
  }

  return (
    <IonPage>
      <Container size={420} my={40}>
        {title}
        <Paper withBorder shadow="md" p={30} mt={30} radius="md">
          <Button onClick={onclick}>Click Me</Button>
        </Paper>
      </Container>
    </IonPage>
  );
};
