using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class DescriptionManager : MonoBehaviour
{
    public Toggle[] partToggles; // Array of toggles corresponding to brain parts
    public TextMeshProUGUI descriptionText; // TMP component inside the scrollable area

    private Dictionary<string, string> partDescriptions = new Dictionary<string, string>();

    void Start()
    {
        // Initialize descriptions for each brain part
        InitializePartDescriptions();

        if (partToggles != null && partToggles.Length > 0 && descriptionText != null)
        {
            foreach (Toggle toggle in partToggles)
            {
                if (toggle != null)
                {
                    toggle.onValueChanged.AddListener(delegate { UpdateDescription(); });
                }
            }

            // Call UpdateDescription once at the start to initialize the text based on current toggle states
            UpdateDescription();
        }
    }

    void InitializePartDescriptions()
    {
        partDescriptions["Cerebral white matter"] = "The cerebral white matter consists of myelinated nerve fibers that connect different parts of the brain, facilitating communication between neurons. It plays a critical role in the brain's ability to process and transmit information efficiently.";
        partDescriptions["Ventricle"] = "The ventricles are a network of interconnected cavities in the brain filled with cerebrospinal fluid (CSF). They cushion the brain, provide nutrients, and remove waste products. The ventricular system includes the lateral ventricles, third ventricle, and fourth ventricle.";
        partDescriptions["Cerebellum white matter"] = "The cerebellum white matter is located within the cerebellum, beneath the cerebellar cortex. It is responsible for the coordination of voluntary movements, balance, and posture by transmitting signals between the cerebellar cortex and other brain regions.";
        partDescriptions["Cerebellum"] = "The cerebellum, often referred to as the 'little brain,' is located at the back of the brain, under the cerebral hemispheres. It is crucial for motor control, balance, and coordination, helping to fine-tune movements and maintain equilibrium.";
        partDescriptions["Thalamus"] = "The thalamus is a large mass of gray matter located in the dorsal part of the diencephalon. It acts as the brain's relay station, receiving sensory information and transmitting it to the appropriate areas of the cerebral cortex for processing.";
        partDescriptions["Caudate"] = "The caudate nucleus is one of the structures that make up the basal ganglia. It is involved in various functions, including motor control, learning, memory, and emotion. The caudate plays a key role in the brain's reward system.";
        partDescriptions["Putamen"] = "The putamen is another component of the basal ganglia, located at the base of the forebrain. It is involved in regulating movements and influences various types of learning. The putamen is closely connected with the caudate nucleus and the globus pallidus.";
        partDescriptions["Pallidum"] = "The pallidum, also known as the globus pallidus, is part of the basal ganglia. It plays a crucial role in regulating voluntary movement, particularly in inhibiting excessive movement. The pallidum works closely with other basal ganglia structures to modulate motor activity.";
        partDescriptions["Brain stem"] = "The brain stem connects the brain to the spinal cord and is responsible for basic life-sustaining functions such as breathing, heart rate, and blood pressure. It also plays a role in regulating the sleep-wake cycle and transmitting motor and sensory information.";
        partDescriptions["Hippocampus"] = "The hippocampus is a small, curved structure located within the medial temporal lobe. It is essential for the formation of new memories and is also involved in learning and emotion. The hippocampus plays a significant role in spatial memory and navigation.";
        partDescriptions["Amygdala"] = "The amygdala is an almond-shaped structure located deep within the temporal lobe. It is primarily associated with the processing of emotions, such as fear and pleasure, and plays a key role in forming emotional memories.";
        partDescriptions["CSF (Cerebrospinal fluid)"] = "Cerebrospinal fluid (CSF) is a clear, colorless body fluid found in the brain and spinal cord. It provides cushioning for the brain, removes waste, and circulates nutrients and chemicals filtered from the blood.";
        partDescriptions["Accumbens-area"] = "The nucleus accumbens is part of the basal forebrain and plays a central role in the reward circuit. It is involved in the release of dopamine, which is critical for motivation, pleasure, and reinforcement learning.";
        partDescriptions["VentralDC"] = "The ventral tegmental area (VTA) is located in the midbrain and is part of the brain's reward system. It is involved in the release of dopamine and plays a role in motivation, cognition, and drug addiction.";
        partDescriptions["Corpus callosum"] = "The corpus callosum is a wide, thick nerve tract consisting of a bundle of commissural fibers that connect the left and right cerebral hemispheres. It allows for communication between the two hemispheres of the brain.";
        partDescriptions["BanksSTS"] = "The banks of the superior temporal sulcus (STS) are involved in processing complex aspects of social cognition, including the perception of faces and the detection of biological motion.";
        partDescriptions["Caudal anterior cingulate"] = "The caudal anterior cingulate cortex (ACC) is involved in a range of functions including emotion regulation, decision making, and cognitive control. It plays a role in processing emotions and managing conflict during decision making.";
        partDescriptions["Caudal middle frontal gyrus"] = "The caudal middle frontal gyrus is involved in executive functions such as working memory, attention, and planning. It is part of the prefrontal cortex, which is critical for higher cognitive functions.";
        partDescriptions["Cuneus"] = "The cuneus is a region of the occipital lobe that plays a role in basic visual processing. It is involved in processing visual information from the retina, particularly related to attention and visual memory.";
        partDescriptions["Entorhinal"] = "The entorhinal cortex is located in the medial temporal lobe and is a critical interface between the hippocampus and the neocortex. It plays a key role in memory formation, spatial navigation, and the consolidation of long-term memories.";
        partDescriptions["Fusiform gyrus"] = "The fusiform gyrus is located in the temporal lobe and is involved in high-level visual processing, particularly the recognition of faces and objects. It is also associated with the processing of color information and word recognition.";
        partDescriptions["Inferior parietal gyrus"] = "The inferior parietal gyrus is located in the parietal lobe and is involved in integrating sensory information, spatial awareness, and attention. It plays a role in language processing and mathematical reasoning.";
        partDescriptions["Inferior temporal gyrus"] = "The inferior temporal gyrus is located in the temporal lobe and is involved in the recognition of objects, faces, and scenes. It plays a key role in visual processing and is critical for the interpretation of complex visual stimuli.";
        partDescriptions["Isthmus cingulate"] = "The isthmus of the cingulate gyrus is part of the limbic system and is involved in emotion formation and processing, learning, and memory. It connects the cingulate gyrus with the parahippocampal gyrus.";
        partDescriptions["Lateral occipital gyrus"] = "The lateral occipital gyrus is part of the occipital lobe and plays a key role in the visual processing of shapes, colors, and motion. It is involved in the identification of objects and visual perception.";
        partDescriptions["Lateral orbitofrontal"] = "The lateral orbitofrontal cortex is involved in decision making, emotional regulation, and social behavior. It plays a role in evaluating rewards and punishments and adjusting behavior based on these evaluations.";
        partDescriptions["Lingual gyrus"] = "The lingual gyrus is located in the occipital lobe and is involved in visual processing, particularly related to letters and complex images. It is also associated with the processing of visual memories and word recognition.";
        partDescriptions["Medial orbitofrontal"] = "The medial orbitofrontal cortex is involved in the processing of rewards, decision making, and emotional regulation. It plays a role in evaluating the value of rewards and guiding behavior based on these evaluations.";
        partDescriptions["Middle temporal gyrus"] = "The middle temporal gyrus is located in the temporal lobe and is involved in the processing of auditory information, language comprehension, and the recognition of known objects and faces.";
        partDescriptions["Parahippocampal"] = "The parahippocampal gyrus is located in the medial temporal lobe and is involved in memory encoding and retrieval, as well as spatial memory and navigation.";
        partDescriptions["Paracentral lobule"] = "The paracentral lobule is located on the medial surface of the cerebral hemisphere and includes parts of the precentral and postcentral gyri. It is involved in motor control, particularly of the lower limbs, and somatosensory processing.";
        partDescriptions["Pars opercularis"] = "The pars opercularis is a region of the frontal lobe and is part of Broca's area, which is involved in language production and processing.";
        partDescriptions["Pars orbitalis"] = "The pars orbitalis is located in the frontal lobe and is involved in language processing, particularly the syntax and grammar of language.";
        partDescriptions["Pars triangularis"] = "The pars triangularis is part of Broca's area in the frontal lobe and is involved in language processing, particularly in syntactic and semantic processing.";
        partDescriptions["Pericalcarine"] = "The pericalcarine cortex is located in the occipital lobe and is involved in the primary visual processing of information received from the retinas.";
        partDescriptions["Postcentral gyrus"] = "The postcentral gyrus is located in the parietal lobe and contains the primary somatosensory cortex, which is responsible for processing tactile sensory information from the body.";
        partDescriptions["Posterior cingulate"] = "The posterior cingulate cortex is part of the limbic system and is involved in memory and emotional processing, as well as self-referential thinking.";
        partDescriptions["Precentral gyrus"] = "The precentral gyrus is located in the frontal lobe and contains the primary motor cortex, which is responsible for voluntary muscle movements.";
        partDescriptions["Precuneus"] = "The precuneus is a region of the parietal lobe and is involved in a variety of complex functions, including episodic memory, self-reflection, and aspects of consciousness.";
        partDescriptions["Rostral anterior cingulate"] = "The rostral anterior cingulate cortex is involved in emotional regulation, decision making, and the processing of pain. It plays a role in managing conflicting information and making value-based decisions.";
        partDescriptions["Rostral middle frontal gyrus"] = "The rostral middle frontal gyrus is part of the prefrontal cortex and is involved in higher cognitive functions such as planning, decision making, and social behavior.";
        partDescriptions["Superior frontal gyrus"] = "The superior frontal gyrus is located in the frontal lobe and is involved in self-awareness, working memory, and the control of movements.";
        partDescriptions["Superior parietal gyrus"] = "The superior parietal gyrus is involved in spatial orientation and the integration of sensory information from different parts of the body. It plays a key role in attention and visual perception.";
        partDescriptions["Superior temporal gyrus"] = "The superior temporal gyrus is located in the temporal lobe and contains the primary auditory cortex, which processes sounds. It is also involved in language comprehension and social cognition.";
        partDescriptions["Supramarginal gyrus"] = "The supramarginal gyrus is part of the parietal lobe and is involved in processing language, particularly in phonological processing and the integration of sensory information.";
        partDescriptions["Frontal pole"] = "The frontal pole is the most anterior part of the prefrontal cortex and is involved in complex cognitive functions such as decision making, problem solving, and the management of social interactions.";
        partDescriptions["Temporal pole"] = "The temporal pole is located at the anterior end of the temporal lobe and is involved in the processing of complex social and emotional information, as well as aspects of semantic memory.";
        partDescriptions["Transverse temporal gyrus"] = "The transverse temporal gyrus, also known as Heschl's gyrus, is located in the temporal lobe and contains the primary auditory cortex. It plays a key role in processing auditory information.";
        partDescriptions["Insula"] = "The insula is located deep within the lateral sulcus and is involved in a variety of functions including emotion, self-awareness, and the perception of bodily sensations.";
    }

    void UpdateDescription()
    {
        if (descriptionText == null)
        {
            return;
        }

        string combinedDescription = "";

        foreach (Toggle toggle in partToggles)
        {
            if (toggle != null && toggle.isOn)
            {
                var textComponent = toggle.GetComponentInChildren<Text>();
                if (textComponent == null)
                {
                    continue;
                }

                string partName = textComponent.text;

                if (partDescriptions.ContainsKey(partName))
                {
                    combinedDescription += "<b>" + partName + ":</b>\n" + partDescriptions[partName] + "\n\n";
                }
            }
        }

        descriptionText.text = combinedDescription;
    }
}
